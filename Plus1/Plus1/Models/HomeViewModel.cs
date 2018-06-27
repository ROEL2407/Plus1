using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{

    public class HomeViewModel
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<Promotion> Promotions { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}