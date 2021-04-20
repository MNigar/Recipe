using RecipeBLL.DTO;
using RecipeBLL.Repository.Menu;
using RecipeDAL.Context;
using RecipeDAL.DAO.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDAL.Repository.Menu
{
   public class MenuRepository :BaseRepository<MenuDTO, MenuDAO, RecipeContext>, IMenuRepository
    {
    }
}
