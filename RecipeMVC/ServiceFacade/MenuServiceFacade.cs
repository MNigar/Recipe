using RecipeBLL.DTO;
using RecipeBLL.Service.Menu;
using RecipeCommon.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeMVC.ServiceFacade
{
    public class MenuServiceFacade : BaseServiceFacade, IBaseServiceFacade<RecipeDTO>
    {
        private readonly MenuService _service;

        public MenuServiceFacade(MenuService service)
        {
            _service = service;
        }

        public IQueryable<RecipeDTO> GetAll()
        {
            var all = _service.GetAll();
            if (all.IsSucceed)
                return all.Data;
            return Enumerable.Empty<RecipeDTO>().AsQueryable();

        }

        public RecipeDTO GetById(int id)
        {
            var all = _service.GetAll();
            if (all.IsSucceed)
                return all.Data.FirstOrDefault(x => x.Id == id);
            return new RecipeDTO();
        }

        public SiteResponse Remove(int id, int userId = 0)
        {
            var response = new SiteResponse();
            var command = _service.Remove(id);
            SetResponse(command, ref response);
            return response;
        }

        public SiteResponse Save(RecipeDTO obj, int userId = 0)
        {
            var response = new SiteResponse();
            var command = _service.Save(obj);
            SetResponse(command, ref response);
            return response;
        }
    }
}