using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string EAN { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Shortdescription { get; set; }
        public string FullDescription { get; set; }
       // public image
        public string Weight { get; set; }
        public decimal Price { get; set; }
      //  public int CategoryID { get; set; }
  //    public int SubcategoryID { get; set; }
      //  public int SubSubcategoryID { get; set; }
  

    }
}