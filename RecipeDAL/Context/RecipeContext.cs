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
        public RecipeContext() : base("Recipe") { }

        public DbSet<MenuDAO> Features { get; set; }
    }

}
