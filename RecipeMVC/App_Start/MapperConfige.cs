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

                CreateMap<MenuViewModel, MenuDTO>().ReverseMap();
            }
        }
    
}