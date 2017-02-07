using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperZapatos.Models;

namespace SuperZapatos.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private SuperZapatos.Models.SuperZapatos db = new SuperZapatos.Models.SuperZapatos();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Store);
            return View(articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.STORE_ID = new SelectList(db.Stores, "STORE_ID", "NAME");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ARTICLE_ID,NAME,DESCRIPTION,PRICE,TOTAL_IN_SHELF,TOTAL_IN_VAULT,STORE_ID")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.ARTICLE_ID = Guid.NewGuid();
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.STORE_ID = new SelectList(db.Stores, "STORE_ID", "NAME", article.STORE_ID);
            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.STORE_ID = new SelectList(db.Stores, "STORE_ID", "NAME", article.STORE_ID);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ARTICLE_ID,NAME,DESCRIPTION,PRICE,TOTAL_IN_SHELF,TOTAL_IN_VAULT,STORE_ID")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.STORE_ID = new SelectList(db.Stores, "STORE_ID", "NAME", article.STORE_ID);
            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
