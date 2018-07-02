using Plus1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Areas.Admin.Models
{
    public class PromotionProducts
    {
        public int PromotionProductsID { get; set; }
        public Product EAN { get; set; }
        public bool Visible { get; set; }
    }
}