﻿using System;
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
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Category.ToList());
        }

        /*// GET: Categories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }*/
        public ActionResult Details(string id)
        {
            Category category = db.Category.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (category == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CategoryViewModel();
                List<Category> Cats = new List<Category>();
                Cats.Add(category);

         viewModel.Products = new List<Product>();
           foreach (Product p in db.Products.Where(c => c.Category == category.Name))
            {
              p.Price = p.Price / 100;
            viewModel.Products.Add(p);

          }
           /* List<SubSubCategory> Dogs = new List<SubSubCategory>();
            Dogs.Add(subsubcategory);
            viewModel.SubSubCategory = Dogs;

            viewModel.Products = new List<Product>();
            foreach (Product p in db.Products.Where(c => c.SubSubcategory == SubSubcategory.Name).Take(100))
            {
                p.Price = p.Price / 100;
                viewModel.Products.Add(p);

            }*/

            //viewModel.Products = db.Products.Where(c => c.Category == category.Name).ToList();
            viewModel.Category = Cats;
            viewModel.SubCategory = db.SubCategory.Where(c => c.ParentName == category.Name).Take(20).ToList();
            return View(viewModel);
        }
        public ActionResult SubDetails(string id)
        {
            Category category = db.Category.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (category == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CategoryViewModel();
            List<Category> Cats = new List<Category>();
            Cats.Add(category);

            viewModel.Products = db.Products.Take(100).ToList();
            viewModel.Category = Cats;
            viewModel.SubCategory = db.SubCategory.Where(c => c.ParentName == category.Name).Take(20).ToList();
            return View(viewModel);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Category.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Category category = db.Category.Find(id);
            db.Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
