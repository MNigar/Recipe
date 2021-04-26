using AutoMapper;
using AutoMapper.QueryableExtensions;
using RecipeBLL.DTO;
using RecipeBLL.Repository;
using RecipeCommon.Response;
using RecipeDAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace RecipeDAL.Repository
{
    public abstract class BaseRepository<TDto, TDao, TContext> : IBaseRepository<TDto> where TDto : BaseDTO
        where TDao : BaseDAO
        where TContext : DbContext
    {
        private TContext ctx;
        private readonly IMapper _mapper;
        public BaseRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual ActionResponse<IQueryable<TDto>> GetAll()
        {
            
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var entities = ctx.Set<TDao>().ProjectTo<TDto>(_mapper.ConfigurationProvider);
                var list = entities.ToList();
                //var entitiess = ctx.Set<TDao>();
                //var t = _mapper.Map<IQueryable<TDto>>(entitiess);
                return ActionResponse<IQueryable<TDto>>.Succeed(entities);
                
            }
            catch (Exception ex)
            {
                return ActionResponse<IQueryable<TDto>>.Failure(ex.Message);
            }
        }
      

        public ActionResponse<TDto> GetById(int id)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var dao = ctx.Set<TDao>().FirstOrDefault(e => e.Id == id);
                var dto = _mapper.Map<TDto>(dao);
                return ActionResponse<TDto>.Succeed(dto);
            }
            catch (Exception ex)
            {
                return ActionResponse<TDto>.Failure(ex.Message);
            }
        }

        public ActionResponse Remove(int id, int userId = 0)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var dao = ctx.Set<TDao>().FirstOrDefault(e => e.Id == id);
                ctx.Entry(dao).State = EntityState.Deleted;
                var result = ctx.SaveChanges();
                return ActionResponse.Succeed();
            }
            catch (Exception ex)
            {
                return ActionResponse<TDto>.Failure(ex.Message);
            }
        }
        private ActionResponse Add(TDto obj, int userId = 0)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var model = _mapper.Map<TDao>(obj);
                //int i = 8;
                ////var id= ctx.Set<TDao>().OrderByDescending(m => m.Id).FirstOrDefault().Id;
                //model.Id = i++;

                model.CreatedUserId = userId;
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = null;
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    if (obj.Id == 0)
                    {
                        ctx.Set<TDao>().Add(model);
                        var result = ctx.SaveChanges();
                    }
                    transaction.Commit();
                    obj.Id = model.Id;
                    return ActionResponse.Succeed();
                }

            }
            catch (Exception ex)
            {
                return ActionResponse<TDto>.Failure(ex.Message);
            }
        }

        private ActionResponse Update(TDto obj, int userId = 0)
        {
            try
            {
                ctx = Activator.CreateInstance<TContext>();
                var model = _mapper.Map<TDao>(obj);
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    var dbModel = ctx.Set<TDao>().FirstOrDefault(x => x.Id == model.Id);
                    dbModel.ModifiedUserId = userId;
                    dbModel.ModifiedDate = DateTime.Now;
                    var entry = ctx.Entry(dbModel);
                    entry.CurrentValues.SetValues(model);
                    entry.Property(x => x.CreatedDate).IsModified = false;
                    entry.Property(x => x.CreatedUserId).IsModified = false;
                    ctx.SaveChanges();
                    transaction.Commit();
                    obj.Id = model.Id;
                    return ActionResponse.Succeed();
                }

            }
            catch (Exception ex)
            {
                return ActionResponse<TDto>.Failure(ex.Message);
            }
        }
        public ActionResponse Save(TDto obj, int userId = 0)
        {
            var response = obj.Id == 0 ? Add(obj, userId) : Update(obj, userId);
            return response;
        }
    }
}
