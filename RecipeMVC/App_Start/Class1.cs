using AutoMapper;
using LightInject;
using RecipeBLL.DTO;
using RecipeBLL.Repository.Menu;
using RecipeDAL.DAO.Menu;
using RecipeDAL.Repository.Menu;
using RecipeMVC.Models;
using RecipeMVC.ServiceFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeMVC.App_Start
{
    public class Class1
    {
        public static void Register(LightInject.ServiceContainer container)
        {
            Config(container);
        }

        private static void Config(LightInject.ServiceContainer container)
        {
            RegisterServiceFacade(container);
            RegisterService(container);
            RegisterRepositories(container);
            RegisterMappers();

        }
        private static void RegisterServiceFacade(LightInject.ServiceContainer serviceContainer)
        {
            serviceContainer.Register<IBaseServiceFacade<RecipeBLL.DTO.RecipeDTO>, MenuServiceFacade>(Lifetime);
        }

        private static void RegisterService(LightInject.ServiceContainer serviceContainer)
        {
            serviceContainer.Register<MenuServiceFacade>(Lifetime);
        }

        private static void RegisterRepositories(LightInject.ServiceContainer serviceContainer)
        {
            serviceContainer.Register<IMenuRepository, MenuRepository>(Lifetime);
        }

        private static void RegisterMappers()
        {
            var config = new MapperConfiguration(cfg =>
            {

                //Create all maps here
                cfg.CreateMap<RecipeDAO, RecipeDTO>();
                cfg.CreateMap<RecipeDTO, RecipeViewModel>()
                //ForMember(vm => vm.Description, map => map.MapFrom(m => m.Description)).
                //ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id)).
                //ForMember(vm => vm.CreatedDate, map => map.MapFrom(m => m.CreatedDate))
                ;




                //...
            });
            IMapper mapper = config.CreateMapper();
        }
       

            //var e = container.Resolve<RecipesController>();

            //e.Index();
          
        public static ILifetime Lifetime
        {
            get { return new PerContainerLifetime(); }
        }


    }
}