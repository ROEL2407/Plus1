using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Plus1.Models;
using Microsoft.AspNet.Identity;

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
        // GET: Cart/Add
        public ActionResult Add(string EAN, int Quantity)
        {
            var userId = User.Identity.GetUserId();
            //Cart data = db.Carts.Find(userId);
            var finddata = db.Carts.Where(a => a.UserId == userId);
            foreach (Cart data in finddata)
            {
                if (!data.Equals(null))
                {
                    CartItem Ci = new CartItem();
                    Ci.EAN = EAN;
                    Ci.Quantity = Quantity;
                    CartItem ex = db.CartItems.Where(a => a.EAN == Ci.EAN && a.CartID == Ci.CartID).FirstOrDefault();

                    if (ex != null)
                    {
                        Ci.Quantity = Ci.Quantity + ex.Quantity;

                        db.Entry(ex).CurrentValues.SetValues(Ci);
                    }
                    else
                    {
                        Ci.CartID = data.CartID;
                        db.CartItems.Add(Ci);
                    }
                }
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