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
    public class AdminSubSubCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AdminSubSubCategories
        public ActionResult Index()
        {
            var subSubCategory = db.SubSubCategory.Include(s => s.Parent);
            return View(subSubCategory.ToList());
        }

        // GET: Admin/AdminSubSubCategories/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.SubSubCategory.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(subSubCategory);
        }

        // GET: Admin/AdminSubSubCategories/Create
        public ActionResult Create()
        {
            ViewBag.ParentName = new SelectList(db.SubCategory, "Name", "ParentName");
            return View();
        }

        // POST: Admin/AdminSubSubCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,ParentName,Image")] SubSubCategory subSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.SubSubCategory.Add(subSubCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentName = new SelectList(db.SubCategory, "Name", "ParentName", subSubCategory.ParentName);
            return View(subSubCategory);
        }

        // GET: Admin/AdminSubSubCategories/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.SubSubCategory.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentName = new SelectList(db.SubCategory, "Name", "ParentName", subSubCategory.ParentName);
            return View(subSubCategory);
        }

        // POST: Admin/AdminSubSubCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,ParentName,Image")] SubSubCategory subSubCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subSubCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentName = new SelectList(db.SubCategory, "Name", "ParentName", subSubCategory.ParentName);
            return View(subSubCategory);
        }

        // GET: Admin/AdminSubSubCategories/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubSubCategory subSubCategory = db.SubSubCategory.Find(id);
            if (subSubCategory == null)
            {
                return HttpNotFound();
            }
            return View(subSubCategory);
        }

        // POST: Admin/AdminSubSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SubSubCategory subSubCategory = db.SubSubCategory.Find(id);
            db.SubSubCategory.Remove(subSubCategory);
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
