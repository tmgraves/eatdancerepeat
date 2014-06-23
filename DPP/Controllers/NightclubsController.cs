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
    public class NightclubsController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Nightclubs
        public ActionResult Index()
        {
            return View(db.Places.OfType<Nightclub>());
        }

        // GET: Nightclubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nightclub nightclub = db.Places.OfType<Nightclub>().Single(n => n.PlaceID == id);
            if (nightclub == null)
            {
                return HttpNotFound();
            }
            return View(nightclub);
        }

        // GET: Nightclubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nightclubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceID,Address,Address2,City,State,Zip,Country")] Nightclub nightclub)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(nightclub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nightclub);
        }

        // GET: Nightclubs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nightclub nightclub = db.Places.OfType<Nightclub>().Single(n => n.PlaceID == id);
            if (nightclub == null)
            {
                return HttpNotFound();
            }
            return View(nightclub);
        }

        // POST: Nightclubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceID,Address,Address2,City,State,Zip,Country")] Nightclub nightclub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nightclub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nightclub);
        }

        // GET: Nightclubs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nightclub nightclub = db.Places.OfType<Nightclub>().Single(n => n.PlaceID == id);
            if (nightclub == null)
            {
                return HttpNotFound();
            }
            return View(nightclub);
        }

        // POST: Nightclubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nightclub nightclub = db.Places.OfType<Nightclub>().Single(n => n.PlaceID == id);
            db.Places.Remove(nightclub);
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
