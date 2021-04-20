using RecipeCommon.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeMVC.ServiceFacade
{
    public abstract  class BaseServiceFacade
    {
        public SiteResponse SetResponse(ActionResponse command, ref SiteResponse response)
        {
            if (!command.IsSucceed)
            {
                response.IsSucceed = false;
                response.Description = string.Join(" ", command.FailureResult);
            }
            return response;
        }
    }
}