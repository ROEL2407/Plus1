using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plus1.Areas.Admin.Controllers
{
   // [Authorize(Roles = "Admin, Webredacteur")]
    public class HomePageController : Controller
    {
        // GET: Admin/HomePage
        public ActionResult Index()
        {
            return View();
        }
    }
}