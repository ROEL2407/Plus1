using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class CartItem
    {
        public Cart CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}