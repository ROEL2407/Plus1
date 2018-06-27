using Plus1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plus1.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
 
        public ActionResult Index()
        {

            var viewModel = new HomeViewModel();
            viewModel.Products = db.Products.ToList();
           // viewModel.Promotions = db.Promotions.ToList();
            viewModel.Categories = db.Category.ToList();
            return View(viewModel);
        }
    }
}