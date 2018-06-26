﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Plus1.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }
        public Cart CartID { get; set; }
        public string EAN { get; set; }
        public int Quantity { get; set; }
    }
}