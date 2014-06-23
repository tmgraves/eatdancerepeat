using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DPP.Models;

namespace DPP.Controllers
{
    public class StudiosController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Studios
        public ActionResult Index()
        {
            var studios = db.Places.Include(s => s.Reviews);
            return View(db.Places.OfType<Studio>());
        }

        // GET: Studios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Places.OfType<Studio>().Single(s => s.PlaceID == id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // GET: Studios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceID,Address,Address2,City,State,Zip,Country")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(studio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studio);
        }

        // GET: Studios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Places.OfType<Studio>().Single(s => s.PlaceID == id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceID,Address,Address2,City,State,Zip,Country")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studio);
        }

        // GET: Studios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = db.Places.OfType<Studio>().Single(s => s.PlaceID == id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studio studio = db.Places.OfType<Studio>().Single(s => s.PlaceID == id);
            db.Places.Remove(studio);
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
