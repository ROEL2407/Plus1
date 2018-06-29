using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plus1.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
        public string EAN { get; set; }
        public int Quantity { get; set; }
    }
}



