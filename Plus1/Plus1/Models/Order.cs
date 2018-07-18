using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plus1.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string Firstname { get; set; } //TODO - moet automatisch worden ingevuld vanuit ASPNETUSERS DB
        public string Surname { get; set; } //TODO - moet automatisch worden ingevuld vanuit ASPNETUSERS DB
        public string Address { get; set; } //TODO - moet automatisch worden ingevuld vanuit ASPNETUSERS DB
        public string Zipcode { get; set; } //TODO - moet automatisch worden ingevuld vanuit ASPNETUSERS DB
        public string City { get; set; } //TODO - moet automatisch worden ingevuld vanuit ASPNETUSERS DB
        public string DeliveryMoment { get; set; }
        public string PaymentMethod { get; set; }
    }
}