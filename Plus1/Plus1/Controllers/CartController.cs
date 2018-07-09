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
        // GET: Cart/Add
        public ActionResult Add(string EAN, int Quantity)
        {
            var userId = User.Identity.GetUserId();
            //Cart data = db.Carts.Find(userId);
            var finddata = db.Carts.Where(a => a.UserId == userId).DefaultIfEmpty(null).First();
                if (finddata != null)
                {
                    Cart UC = finddata;
                    CartItem Ci = new CartItem();
                    Ci.EAN = EAN;
                    Ci.CartID = UC.CartID;
                    int OldQuantity = Ci.Quantity;
                    CartItem ex = db.CartItems.Where(a => a.EAN == Ci.EAN && a.CartID == Ci.CartID).DefaultIfEmpty(null).First();

                    if (ex != null)
                    {
                        Ci.Quantity = OldQuantity + ex.Quantity;
                        db.Entry(ex).CurrentValues.SetValues(Ci);
                        db.SaveChanges();
                    }
                    else
                    {
                        Ci.Quantity = Quantity;
                        db.CartItems.Add(Ci);
                        db.SaveChanges();
                }
                }
            return RedirectToAction("Details");
        }

        public ActionResult Remove(string EAN)
        {
            var userId = User.Identity.GetUserId();
            //Cart data = db.Carts.Find(userId);
            var finddata = db.Carts.Where(a => a.UserId == userId).DefaultIfEmpty(null).First();
            if (finddata != null)
            {
                Cart UC = finddata;
                CartItem Ci = new CartItem();
                Ci.EAN = EAN;
                Ci.CartID = UC.CartID;
                var OldQuantity = Ci.Quantity;
                CartItem ex = db.CartItems.Where(a => a.EAN == Ci.EAN && a.CartID == Ci.CartID).DefaultIfEmpty(null).First();

                if (ex != null)
                {
                    db.CartItems.Remove(ex);
                    db.SaveChanges();
                }
                else
                {
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            Cart UserCart = db.Carts.Where(Cart => Cart.UserId == userId).DefaultIfEmpty(null).FirstOrDefault();

            CartViewModel CVM = new CartViewModel();
            List<CartItemViewModel> CVIM = new List<CartItemViewModel>();
            if (UserCart == null)
            {
                return View("Empty");
            }
            else
            {
                foreach (CartItem c in db.CartItems.Where(Ci => Ci.CartID == UserCart.CartID))
                {
                    Product p = db.Products.Find(c.EAN);
                    CartItemViewModel CartModel = new CartItemViewModel();
                    CartModel.EAN = c.EAN;
                    CartModel.Quantity = c.Quantity;
                    CartModel.Title = p.Title;
                    CartModel.Image = p.Image;
                    CartModel.Price = p.Price / 100;
                    CVIM.Add(CartModel);
                }

                CVM.Items = CVIM;
                return View(CVM);
            }
        }
    }
}