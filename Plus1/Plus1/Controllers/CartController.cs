using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plus1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Plus1.Controllers
{
    public class CartController : Controller
    {
        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Add(string EAN, int Quantity)
        {
            Cart c = new Cart();
            DateTime today = DateTime.Now;
            c.Expirationdate = today.AddDays(7);
            c.User.Id = User.Identity.GetUserId();
            var data = db.Carts.Find(c);
            if (!data.Equals(data))
            {
                CartItem Ci = new CartItem();
                Ci.CartID = c;
                Ci.EAN = EAN;
                Ci.Quantity = Quantity;
                CartItem ex = db.CartItems.Find(Ci.CartID, Ci.EAN);
                if (ex != null)
                {
                    Ci.Quantity = Ci.Quantity + ex.Quantity;
                    db.Entry(ex).CurrentValues.SetValues(Ci);
                }
                else
                {
                    db.CartItems.Add(Ci);
                }
            }
            else
            {
                db.Carts.Add(c);
                CartItem Ci = new CartItem();
                Ci.CartID = c;
                Ci.EAN = EAN;
                Ci.Quantity = Quantity;
                db.CartItems.Add(Ci);
            }
            db.SaveChanges();
            return RedirectToAction("Details");
        }
        public ActionResult GetCartDefault()
        {
            string Response = 
                "{" +
                    "'Status': 'Fail'," +
                    "'Message': 'Log in om producten toe te voegen en te bestellen!'," +
                "}";
            return Json(Response, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult GetCart(ApplicationUser u)
        {
            string Response =
            "{" +
                "'Status': 'Success'," +
                "'Message': 'Welkom terug, " + u.UserName + "'," +
            "}";
            return Json(Response, JsonRequestBehavior.AllowGet);
        }
    }
}