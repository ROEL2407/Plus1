using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class CartViewModel
    {
        public ICollection<CartItemViewModel> Items { get; set; }
    }
}