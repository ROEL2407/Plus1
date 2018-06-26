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
        /*
    [HttpPost]
    [Authorize]
public ActionResult Add(string EAN, int Quantity)
    {
        Cart c = new Cart();
        DateTime today = DateTime.Now;
        c.Expirationdate = today.AddDays(7);
        c.User.Id = User.Identity.GetUserId();
        if (db.Carts.Find(c.User) != null)
        {
            CartItem Ci = new CartItem();
            Ci.CartID = c;
            Ci.ProductID = int.Parse(EAN);
            Ci.Quantity = Quantity;
            db.CartItems.Add(Ci);
        }
        else
        {
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            Cart c = new Cart();
            DateTime today = DateTime.Now;
            c.Expirationdate = today.AddDays(7);
            c.User.Id = User.Identity.GetUserId();
            if (db.Carts.Find(c.User) != null)
            {
                CartItem Ci = new CartItem();
                Ci.CartID = c;
                Ci.EAN = EAN; 
                Ci.Quantity = Quantity;
                db.CartItems.Add(Ci);
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
            return Json(new { foo = "bar", baz = "Blech" });
=======
            db.Carts.Add(c);
            CartItem Ci = new CartItem();
            Ci.CartID = c;
            Ci.ProductID = int.Parse(EAN);
            Ci.Quantity = Quantity;
            db.CartItems.Add(Ci);
>>>>>>> 27a0f223759b35e42ccf5c3546958b4448c2e107
        }
        db.SaveChanges();
        return RedirectToAction("Details");
    }*/
    }
}