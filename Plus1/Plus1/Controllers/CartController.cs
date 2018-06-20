using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plus1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return Json("Silece is golden", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Add(int ProductID, int Quantity )
        {
            return Json("Succes", JsonRequestBehavior.AllowGet);
        }
    }
}