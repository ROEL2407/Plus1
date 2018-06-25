using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Expirationdate { get; set;}

    }
}