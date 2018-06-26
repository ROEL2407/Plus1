using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Plus1.Models
{
    public class CartItem
    {
<<<<<<< HEAD
        [Key]
        public int CartItemID { get; set; }
=======
       // [Key]
        public int CartItemID { get; set; } //Groeten Koen. Anders was er geen 'key'
>>>>>>> 27a0f223759b35e42ccf5c3546958b4448c2e107
        public Cart CartID { get; set; }
        public string EAN { get; set; }
        public int Quantity { get; set; }
    }
}