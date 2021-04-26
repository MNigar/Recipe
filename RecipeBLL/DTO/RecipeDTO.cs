using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBLL.DTO
{
   public  class RecipeDTO:BaseDTO
    {
        public string Ingridients { get; set; }


        public string Quantity { get; set; }
        public string Description { get; set; }

        public int Status { get; set; }
        public int CategoryId { get; set; }
        //public virtual CategoryDAO Category { get; set; }
        public int UserId { get; set; }
        //public virtual UserDAO User { get; set; }
    }
}
