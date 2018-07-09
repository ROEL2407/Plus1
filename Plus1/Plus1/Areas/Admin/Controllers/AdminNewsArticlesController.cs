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
   // [Authorize(Roles = "Admin, Webredacteur")]
    public class AdminNewsArticlesController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/AdminNewsArticles
        public ActionResult Index()
        {
            return View(db.NewsArticles.ToList());
        }

        // GET: Admin/AdminNewsArticles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsArticle model)
        {
            var db = new ApplicationDbContext();


            db.NewsArticles.Add(new NewsArticle
            {
                NewsArticleID = model.NewsArticleID,
                Title = model.Title,
                Content = model.Content,
                Date = DateTime.Now
            });
            db.SaveChanges();
            //return RedirectToAction("index");


            return View(model);
        }

        // GET: Admin/AdminNewsArticles/Create
        public ActionResult Create()
        {
            return View();
        }/*

        // POST: Admin/AdminNewsArticles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewsArticleID,Title,Content,Date")] NewsArticle newsArticle)
        {
            if (ModelState.IsValid)
            {
                db.NewsArticles.Add(newsArticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsArticle);
        }*/

        // GET: Admin/AdminNewsArticles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // POST: Admin/AdminNewsArticles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewsArticleID,Title,Content,Date")] NewsArticle newsArticle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsArticle);
        }

        // GET: Admin/AdminNewsArticles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            if (newsArticle == null)
            {
                return HttpNotFound();
            }
            return View(newsArticle);
        }

        // POST: Admin/AdminNewsArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsArticle newsArticle = db.NewsArticles.Find(id);
            db.NewsArticles.Remove(newsArticle);
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
