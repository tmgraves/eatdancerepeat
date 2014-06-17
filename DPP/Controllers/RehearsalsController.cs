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
    public class RehearsalsController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Rehearsals
        public ActionResult Index()
        {
            var rehearsals = db.Rehearsals.Include(r => r.Place).Include(r => r.Team);
            return View(rehearsals.ToList());
        }

        // GET: Rehearsals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rehearsal rehearsal = db.Rehearsals.Find(id);
            if (rehearsal == null)
            {
                return HttpNotFound();
            }
            return View(rehearsal);
        }

        // GET: Rehearsals/Create
        public ActionResult Create()
        {
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceType");
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName");
            return View();
        }

        // POST: Rehearsals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RehearsalID,TeamID,PlaceID,Day,Time")] Rehearsal rehearsal)
        {
            if (ModelState.IsValid)
            {
                db.Rehearsals.Add(rehearsal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceType", rehearsal.PlaceID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", rehearsal.TeamID);
            return View(rehearsal);
        }

        // GET: Rehearsals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rehearsal rehearsal = db.Rehearsals.Find(id);
            if (rehearsal == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceType", rehearsal.PlaceID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", rehearsal.TeamID);
            return View(rehearsal);
        }

        // POST: Rehearsals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RehearsalID,TeamID,PlaceID,Day,Time")] Rehearsal rehearsal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rehearsal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceType", rehearsal.PlaceID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", rehearsal.TeamID);
            return View(rehearsal);
        }

        // GET: Rehearsals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rehearsal rehearsal = db.Rehearsals.Find(id);
            if (rehearsal == null)
            {
                return HttpNotFound();
            }
            return View(rehearsal);
        }

        // POST: Rehearsals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rehearsal rehearsal = db.Rehearsals.Find(id);
            db.Rehearsals.Remove(rehearsal);
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
