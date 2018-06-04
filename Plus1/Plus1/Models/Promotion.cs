using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public string Title { get; set; }
        public string EAN { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime ValidUntil { get; set; }      
    }
}