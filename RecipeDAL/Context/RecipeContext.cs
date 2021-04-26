using RecipeDAL.DAO.Menu;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDAL.Context
{
  public  class RecipeContext : DbContext
    {
        public  RecipeContext() : base("Recipe") { }

        public virtual DbSet<RecipeDAO> Recipes { get; set; }
        public virtual DbSet<UserDAO> Users { get; set; }
        public virtual DbSet<CategoryDAO> Categories { get; set; }

        //public System.Data.Entity.DbSet<RecipeMVC.Models.MenuViewModel> MenuViewModels { get; set; }
    }

}
