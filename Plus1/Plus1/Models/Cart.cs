using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime Expirationdate { get; set;}
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}