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
            if (Session["cart"] == null)
            {
                List<Product> li = new List<Product>();
                Product p = db.Products.Find(EAN);
                li.Add(p);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = 1;
            }
            else
            {
                List<Product> li = (List<Product>)Session["cart"];
                Product p = db.Products.Find(EAN);
                li.Add(p);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
            }
            return RedirectToAction("Index", "Cart");
        }
        /*{
            Cart c = new Cart();
            DateTime today = DateTime.Now;
            c.Expirationdate = today.AddDays(7);
            var userId = User.Identity.GetUserId();
            c.UserId = userId;
            Guid guid = Guid.NewGuid();
            Random random = new Random();
            int i = random.Next();
            c.CartID = i;
            var data = db.Carts.Where(a => a.UserId == c.UserId);
            if (!data.Equals(null))
            {
                CartItem Ci = new CartItem();
                Ci.CartID = c.CartID;
                Ci.EAN = EAN;
                Ci.Quantity = Quantity;
                CartItem ex = null; 
                try
                {
                    ex = db.CartItems.Where(a => a.EAN == Ci.EAN && a.CartID == Ci.CartID).FirstOrDefault();
                }
                catch
                {

                }
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
                c.CartID = i;
                db.Carts.Add(c);
                CartItem Ci = new CartItem();
                Ci.CartID = c.CartID;
                Ci.EAN = EAN;
                Ci.Quantity = Quantity;
                db.CartItems.Add(Ci);
            }
            db.SaveChanges();
            return RedirectToAction("Details");
        }*/
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