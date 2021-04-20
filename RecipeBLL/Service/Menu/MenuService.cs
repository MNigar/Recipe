using RecipeBLL.DTO;
using RecipeBLL.Repository.Menu;
using RecipeBLL.Validators;
using RecipeCommon.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBLL.Service.Menu
{
    public class MenuService : IBaseService<MenuDTO>
    {
        private readonly IMenuRepository _repository;

        public MenuService(IMenuRepository repository)
        {
            _repository = repository;
        }
        public ActionResponse<IQueryable<MenuDTO>> GetAll()
        {
            var response = _repository.GetAll();
            return response;
        }

        public ActionResponse<MenuDTO> GetById(int id)
        {
            var response = _repository.GetById(id);
            return response;
        }

        public ActionResponse Remove(int id, int userId = 0)
        {
            var response = _repository.Remove(id, userId);
            return response;
        }

        public ActionResponse Save(MenuDTO obj, int userId = 0)
        {
            try
            {
                var valResult = new MenuValidator().Validate(obj);
                if (valResult.IsValid)
                {
                    var response = _repository.Save(obj);
                    return response;
                }

                else
                {
                    var valErrors = valResult.Errors.Select(x => x.ErrorMessage).ToArray();
                    return ActionResponse.Failure(valErrors);
                }
            }
            catch (Exception ex)
            {
                return ActionResponse.Failure(ex.Message);
            }
        }
    }
}
