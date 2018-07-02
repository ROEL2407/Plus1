using Plus1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Plus1.Controllers
{
    public class SubSubCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: SubSubCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(string id)
        {
            SubSubCategory SubSubcategory = db.SubSubCategory.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (SubSubcategory == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CategoryViewModel();
            List<SubSubCategory> Cats = new List<SubSubCategory>();
            Cats.Add(SubSubcategory);
            viewModel.SubSubCategory = Cats;
            viewModel.Products = db.Products.Where(c => c.SubSubcategory == SubSubcategory.Name).Take(100).ToList();
            return View(viewModel);
        }
    }
}