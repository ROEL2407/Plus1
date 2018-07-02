using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class CategoryViewModel
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> Category { get; set; }
        public ICollection<SubCategory> SubCategory { get; set; }
        public ICollection<SubSubCategory> SubSubCategory { get; set; }
    }
}