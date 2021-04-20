using RecipeMVC.ServiceFacade;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using AutoMapper;
using LightInject;
using RecipeBLL.Repository.Menu;
using RecipeDAL.Repository.Menu;

namespace RecipeMVC.App_Start
{
    public class ServiceConfig
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
            serviceContainer.Register<IBaseServiceFacade<RecipeBLL.DTO.MenuDTO>, MenuServiceFacade>(Lifetime);
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
            Mapper.Initialize(x =>
            {
                x.AddProfile<MapperConfig>();
            });
        }

        public static ILifetime Lifetime
        {
            get { return new PerContainerLifetime(); }
        }
    }
}