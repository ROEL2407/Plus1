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
            var products = from m in db.Products select m;
            //TODO - CHECKEN OF Promotion TRUE IS
           // products = products.Where(s => s.Promotion == true );


           // return View(products);

            var viewModel = new HomeViewModel();
    
            viewModel.Products = db.Products.Where(s => s.Promotion == true).ToList();
            viewModel.NewsArticle = db.NewsArticles.Take(20).ToList();
            viewModel.Categories = db.Category.Take(3).ToList();
            return View(viewModel);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}