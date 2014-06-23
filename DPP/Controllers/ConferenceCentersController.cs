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
    public class ConferenceCentersController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: ConferenceCenters
        public ActionResult Index()
        {
            return View(db.Places.OfType<ConferenceCenter>());
        }

        // GET: ConferenceCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferenceCenter conferenceCenter = db.Places.OfType<ConferenceCenter>().Single(c => c.PlaceID == id);
            if (conferenceCenter == null)
            {
                return HttpNotFound();
            }
            return View(conferenceCenter);
        }

        // GET: ConferenceCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConferenceCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceID,Address,Address2,City,State,Zip,Country")] ConferenceCenter conferenceCenter)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(conferenceCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conferenceCenter);
        }

        // GET: ConferenceCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferenceCenter conferenceCenter = db.Places.OfType<ConferenceCenter>().Single(c => c.PlaceID == id);
            if (conferenceCenter == null)
            {
                return HttpNotFound();
            }
            return View(conferenceCenter);
        }

        // POST: ConferenceCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceID,Address,Address2,City,State,Zip,Country")] ConferenceCenter conferenceCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conferenceCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conferenceCenter);
        }

        // GET: ConferenceCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferenceCenter conferenceCenter = db.Places.OfType<ConferenceCenter>().Single(c => c.PlaceID == id);
            if (conferenceCenter == null)
            {
                return HttpNotFound();
            }
            return View(conferenceCenter);
        }

        // POST: ConferenceCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConferenceCenter conferenceCenter = db.Places.OfType<ConferenceCenter>().Single(c => c.PlaceID == id);
            db.Places.Remove(conferenceCenter);
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
