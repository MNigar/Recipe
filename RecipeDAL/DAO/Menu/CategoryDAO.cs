using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDAL.DAO.Menu
{   [Table("Category")]
    public class CategoryDAO:BaseDAO
    {
        public CategoryDAO()
        {
            Recipes = new HashSet<RecipeDAO>();
        }
             
        public string Name { get; set; }
        public virtual HashSet<RecipeDAO> Recipes { get; set; }
        public int UserId { get; set; }
        public virtual UserDAO UserDAO { get; set; }

    }
}
