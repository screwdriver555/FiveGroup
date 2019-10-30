using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FiveGroup.Models;

namespace FiveGroup.Controllers
{
    public class IngrediantsController : Controller
    {
        private Project2Entities db = new Project2Entities();

        // GET: ingrediants
        public ActionResult Index()
        {
            return View(db.ingrediant.ToList());
        }

        // GET: ingrediants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingrediant ingrediant = db.ingrediant.Find(id);
            if (ingrediant == null)
            {
                return HttpNotFound();
            }
            return View(ingrediant);
        }

        // GET: ingrediants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ingrediants/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ing_id,ing_name,ing_eng_name,ing_category,ing_restricted,ing_limitation")] ingrediant ingrediant)
        {
            if (ModelState.IsValid)
            {
                db.ingrediant.Add(ingrediant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingrediant);
        }

        // GET: ingrediants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingrediant ingrediant = db.ingrediant.Find(id);
            if (ingrediant == null)
            {
                return HttpNotFound();
            }
            return View(ingrediant);
        }

        // POST: ingrediants/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ing_id,ing_name,ing_eng_name,ing_category,ing_restricted,ing_limitation")] ingrediant ingrediant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingrediant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingrediant);
        }

        // GET: ingrediants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingrediant ingrediant = db.ingrediant.Find(id);
            if (ingrediant == null)
            {
                return HttpNotFound();
            }
            return View(ingrediant);
        }

        // POST: ingrediants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ingrediant ingrediant = db.ingrediant.Find(id);
            db.ingrediant.Remove(ingrediant);
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
