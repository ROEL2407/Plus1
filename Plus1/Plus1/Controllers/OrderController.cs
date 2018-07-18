using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Plus1.Models;

namespace Plus1.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        // GET: 
        public ActionResult Finish(string _Firstname, string _Surname, string _Adress, string _Zipcode, string _City, string _DeliveryMoment, string _PaymentMethod)
        {
            var userId = User.Identity.GetUserId();

            Cart UserCart = db.Carts.Where(Cart => Cart.UserId == userId).DefaultIfEmpty(null).FirstOrDefault();
  
            Order o = new Order();
            o.Address = _Adress;
            o.Firstname = _Firstname;
            o.Surname = _Surname;
            o.Zipcode = _Zipcode;
            o.DeliveryMoment = _DeliveryMoment;

            o.UserId = userId;

            db.Order.Add(o);

            foreach (CartItem c in db.CartItems.Where(Ci => Ci.CartID == UserCart.CartID))
            {
                OrderItem i = new OrderItem();
                i.EAN = c.EAN;
                i.Quantity = c.Quantity;
                i.OrderID = o.OrderID;
                db.OrderItem.Add(i);
                db.CartItems.Remove(c); // Removing the item from the users cart.
            }
            db.SaveChanges();

            return View(o);
        }

    }
}