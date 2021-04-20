using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDAL.DAO.Menu
{
    [Table("Menu")]
    public  class MenuDAO:BaseDAO
    {
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
