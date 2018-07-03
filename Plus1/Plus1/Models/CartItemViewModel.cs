using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class CartItemViewModel
    {
        public string EAN { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}