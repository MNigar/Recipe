using AutoMapper;
using RecipeBLL.DTO;
using RecipeBLL.Repository.Menu;
using RecipeDAL.DAO.Menu;
using RecipeDAL.Repository.Menu;
using RecipeMVC.Models;
using RecipeMVC.ServiceFacade;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RecipeMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IMenuRepository,MenuRepository>();
            container.RegisterType<MenuServiceFacade>();
            container.RegisterType<IBaseServiceFacade<RecipeBLL.DTO.RecipeDTO>, MenuServiceFacade>();
            
            var config = new MapperConfiguration(cfg =>
            
            {

                //Create all maps here
                cfg.CreateMap<RecipeDAO, RecipeDTO>();
                cfg.CreateMap<RecipeDTO, RecipeViewModel>();
                cfg.CreateMap<RecipeViewModel, RecipeDTO>();
                //cfg.CreateMap<RecipeViewModel, RecipeDTO>();

                cfg.CreateMap<SaveRecipeViewModel, RecipeDTO>();
                cfg.CreateMap<RecipeDTO,SaveRecipeViewModel>();
                cfg.CreateMap<RecipeDTO, RecipeDAO>();
                //ForMember(vm => vm.Description, map => map.MapFrom(m => m.Description)).
                //ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id)).
                //ForMember(vm => vm.CreatedDate, map => map.MapFrom(m => m.CreatedDate))
                ;
               



                //...
            });
            IMapper mapper = config.CreateMapper();

            //var e = container.Resolve<RecipesController>();

            //e.Index();
            container.RegisterInstance(mapper);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}