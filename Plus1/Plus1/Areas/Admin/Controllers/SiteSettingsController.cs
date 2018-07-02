using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Plus1.Areas.Admin.Models;
using Plus1.Models;

namespace Plus1.Areas.Admin.Controllers
{
    public class SiteSettingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/SiteSettings
        public ActionResult Index()
        {
            return View(db.SiteSettings.ToList());
        }

        // GET: Admin/SiteSettings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSettings siteSettings = db.SiteSettings.Find(id);
            if (siteSettings == null)
            {
                return HttpNotFound();
            }
            return View(siteSettings);
        }

        // GET: Admin/SiteSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SiteSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteSettingsID,Visible")] SiteSettings siteSettings)
        {
            if (ModelState.IsValid)
            {
                db.SiteSettings.Add(siteSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteSettings);
        }

        // GET: Admin/SiteSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSettings siteSettings = db.SiteSettings.Find(id);
            if (siteSettings == null)
            {
                return HttpNotFound();
            }
            return View(siteSettings);
        }

        // POST: Admin/SiteSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiteSettingsID,Visible")] SiteSettings siteSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteSettings);
        }

        // GET: Admin/SiteSettings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteSettings siteSettings = db.SiteSettings.Find(id);
            if (siteSettings == null)
            {
                return HttpNotFound();
            }
            return View(siteSettings);
        }

        // POST: Admin/SiteSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteSettings siteSettings = db.SiteSettings.Find(id);
            db.SiteSettings.Remove(siteSettings);
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
