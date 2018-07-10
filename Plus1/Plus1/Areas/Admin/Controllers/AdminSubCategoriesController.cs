using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plus1.Models;

namespace Plus1.Areas.Admin.Controllers
{
    public class AdminSubCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AdminSubCategories
        public ActionResult Index()
        {
            var subCategory = db.SubCategory.Include(s => s.Parent);
            return View(subCategory.ToList());
        }

        // GET: Admin/AdminSubCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // GET: Admin/AdminSubCategories/Create
        public ActionResult Create()
        {
            ViewBag.ParentName = new SelectList(db.Category, "Name", "Image");
            return View();
        }

        // POST: Admin/AdminSubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,ParentName,Image")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.SubCategory.Add(subCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentName = new SelectList(db.Category, "Name", "Image", subCategory.ParentName);
            return View(subCategory);
        }

        // GET: Admin/AdminSubCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentName = new SelectList(db.Category, "Name", "Image", subCategory.ParentName);
            return View(subCategory);
        }

        // POST: Admin/AdminSubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,ParentName,Image")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentName = new SelectList(db.Category, "Name", "Image", subCategory.ParentName);
            return View(subCategory);
        }

        // GET: Admin/AdminSubCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategory.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        // POST: Admin/AdminSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SubCategory subCategory = db.SubCategory.Find(id);
            db.SubCategory.Remove(subCategory);
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
