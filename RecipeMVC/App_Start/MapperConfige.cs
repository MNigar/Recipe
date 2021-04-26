using RecipeBLL.DTO;
using RecipeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeMVC.App_Start
{
   
        public class MapperConfig : AutoMapper.Profile
        {
            public MapperConfig()
            {
                AllowNullCollections = true;

                CreateMap<RecipeViewModel, RecipeDTO>().ReverseMap().
           
               ForMember(vm => vm.Description, map => map.MapFrom(m => m.Description)).
               ForMember(vm => vm.Id, map => map.MapFrom(m => m.Id)).
               ForMember(vm => vm.CreatedDate, map => map.MapFrom(m => m.CreatedDate))
               ;
        }
        }
    
}