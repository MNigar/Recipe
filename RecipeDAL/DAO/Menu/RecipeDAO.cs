using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeDAL.DAO.Menu
{
    [Table("Recipe")]
    public  class RecipeDAO:BaseDAO
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
