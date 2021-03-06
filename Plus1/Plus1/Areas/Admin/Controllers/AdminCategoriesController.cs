﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plus1.Models;

namespace Plus1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AdminCategories
        public ActionResult Index()
        {
            return View(db.Category.ToList());
        }

        // GET: Admin/AdminCategories/Details/5
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
        }

      
        // GET: Admin/AdminCategories/Edit/5
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

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, HttpPostedFileBase fileUpload)
        {

            if (ModelState.IsValid && fileUpload != null && fileUpload.ContentLength > 0)
            {
               // var db = new ApplicationDbContext();


                string fileGuid = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(fileUpload.FileName);
                string newFilename = fileGuid + extension;

                string uploadPath = Path.Combine(Server.MapPath("~/Content/uploads/"));

                fileUpload.SaveAs(Path.Combine(uploadPath, newFilename));

                category.Image = newFilename;

             
               // db.SaveChanges();
               // return RedirectToAction("index");
                if (ModelState.IsValid)
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
          
            return View(category);
        }

        // GET: Admin/AdminCategories/Delete/5
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

        // POST: Admin/AdminCategories/Delete/5
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
