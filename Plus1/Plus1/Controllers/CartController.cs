using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
       /* public ActionResult Add(string EAN, int Quantity)
        {
            db.Products.Add(CartItem);
            db.SaveChanges();
            return RedirectToAction("Details");
        }*/
    }
}