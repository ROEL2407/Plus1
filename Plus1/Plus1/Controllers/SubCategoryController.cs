using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plus1.Models;

namespace Plus1.Controllers
{
    public class SubCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SubCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            SubCategory Subcategory = db.SubCategory.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Subcategory == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CategoryViewModel();
            List<SubCategory> Cats = new List<SubCategory>();
            Cats.Add(Subcategory);
            viewModel.SubCategory = Cats;

            viewModel.Products = new List<Product>();
            foreach (Product p in db.Products.Take(100))
            {
                p.Price = p.Price / 100;
                viewModel.Products.Add(p);

            }


          //  viewModel.Products = db.Products.Take(100).ToList();
            viewModel.SubSubCategory = db.SubSubCategory.Where(c => c.ParentName == Subcategory.Name).Take(20).ToList();
            return View(viewModel);
        }
    }
}