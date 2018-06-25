using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Plus1.Models;

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
                db.Carts.Add(c);
                CartItem Ci = new CartItem();
                Ci.CartID = c;
                Ci.ProductID = int.Parse(EAN);
                Ci.Quantity = Quantity;
                db.CartItems.Add(Ci);
            }
            db.SaveChanges();
            return RedirectToAction("Details");
        }
    }
}