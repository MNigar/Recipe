using RecipeBLL.DTO;
using RecipeCommon.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeMVC.ServiceFacade
{
    public interface IBaseServiceFacade<TDto> where TDto : BaseDTO
    {
        IQueryable<TDto> GetAll();
        TDto GetById(int id);
        SiteResponse Remove(int id, int userId = 0);
        SiteResponse Save(TDto obj, int userId = 0);
    }
    
}