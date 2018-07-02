using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class Product
    {
        [Key]
        public string EAN { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Shortdescription { get; set; }
        public string FullDescription { get; set; }
        public string Image { get; set; }
        public string Weight { get; set; }
        public decimal Price { get; set; }

        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string SubSubcategory { get; set; }

        public bool Promotion { get; set; }
  

    }
}