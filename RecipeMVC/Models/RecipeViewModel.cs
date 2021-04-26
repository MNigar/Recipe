using RecipeCommon.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeMVC.Models
{
    public class RecipeViewModel : BaseViewModel
    {

        //[Required(ErrorMessageResourceType = typeof(UIT), ErrorMessageResourceName = nameof(UIT.CannotbeEmpty))]
        //public string Icon { get; set; }
        [Required(ErrorMessageResourceType = typeof(UIT), ErrorMessageResourceName = nameof(UIT.CannotbeEmpty))]
        public string Description { get; set; }
    }

}