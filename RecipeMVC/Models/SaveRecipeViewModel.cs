using RecipeDAL.DAO.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeMVC.Models
{
    public class SaveRecipeViewModel:BaseViewModel
    {
        [MaxLength(200)]
        public string Ingridients { get; set; }


        public string Quantity { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public int Status { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryDAO Category { get; set; }
        public int UserId { get; set; }
        public virtual UserDAO User { get; set; }
    }
}