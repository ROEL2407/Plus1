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
    public class PromotionProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PromotionProducts
        public ActionResult Index()
        {
            return View(db.SiteSettings.ToList());
        }

        // GET: Admin/PromotionProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionProducts promotionProducts = db.SiteSettings.Find(id);
            if (promotionProducts == null)
            {
                return HttpNotFound();
            }
            return View(promotionProducts);
        }

        // GET: Admin/PromotionProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PromotionProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PromotionProductsID,Visible")] PromotionProducts promotionProducts)
        {
            if (ModelState.IsValid)
            {
                db.SiteSettings.Add(promotionProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promotionProducts);
        }

        // GET: Admin/PromotionProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionProducts promotionProducts = db.SiteSettings.Find(id);
            if (promotionProducts == null)
            {
                return HttpNotFound();
            }
            return View(promotionProducts);
        }

        // POST: Admin/PromotionProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PromotionProductsID,Visible")] PromotionProducts promotionProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promotionProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promotionProducts);
        }

        // GET: Admin/PromotionProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionProducts promotionProducts = db.SiteSettings.Find(id);
            if (promotionProducts == null)
            {
                return HttpNotFound();
            }
            return View(promotionProducts);
        }

        // POST: Admin/PromotionProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PromotionProducts promotionProducts = db.SiteSettings.Find(id);
            db.SiteSettings.Remove(promotionProducts);
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
