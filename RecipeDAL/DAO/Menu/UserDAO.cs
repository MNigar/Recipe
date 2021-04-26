using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDAL.DAO.Menu
{
    [Table("User")]
    public  class UserDAO:BaseDAO
    {   public UserDAO()
        {
            Categories = new HashSet<CategoryDAO>();
            Recipes = new HashSet<RecipeDAO>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int Status { get; set; }
        public virtual HashSet<CategoryDAO> Categories { get; set; }
        public virtual HashSet<RecipeDAO> Recipes { get; set; }

    }
}
