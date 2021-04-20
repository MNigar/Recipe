using RecipeCommon.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCommon.Response
{
    public class SiteResponse
    {
        public bool IsSucceed { get; set; }
        public string Description { get; set; }

        public SiteResponse()
        {
            IsSucceed = true;
            Description = UIT.SuccessOperation;
        }

        public void Success()
        {
            IsSucceed = true;
            Description = UIT.SuccessOperation;
        }

        public void Success(string description)
        {
            IsSucceed = true;
            Description = description;
        }

        public void Failure()
        {
            IsSucceed = false;
            Description = UIT.FailureOperation;
        }
    }
}
