using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeMVC.Models
{
    public class BaseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}