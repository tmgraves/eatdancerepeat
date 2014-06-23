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
            var events = db.Events.Include(r => r.Group);
            return View(events.ToList());
        }

        // GET: Rehearsals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rehearsal rehearsal = db.Events.Find(id);
            if (rehearsal == null)
            {
                return HttpNotFound();
            }
            return View(rehearsal);
        }

        // GET: Rehearsals/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            return View();
        }

        // POST: Rehearsals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,StartTime,EndTime,AllDay,Link,Cost,LocationType,Address,Address2,City,State,Zip,Country,ParentEventID,Frequency,DaysOfWeek,GroupID")] Rehearsal rehearsal)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(rehearsal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", rehearsal.GroupID);
            return View(rehearsal);
        }

        // GET: Rehearsals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rehearsal rehearsal = db.Events.Find(id);
            if (rehearsal == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", rehearsal.GroupID);
            return View(rehearsal);
        }

        // POST: Rehearsals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,StartTime,EndTime,AllDay,Link,Cost,LocationType,Address,Address2,City,State,Zip,Country,ParentEventID,Frequency,DaysOfWeek,GroupID")] Rehearsal rehearsal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rehearsal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", rehearsal.GroupID);
            return View(rehearsal);
        }

        // GET: Rehearsals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rehearsal rehearsal = db.Events.Find(id);
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
            Rehearsal rehearsal = db.Events.Find(id);
            db.Events.Remove(rehearsal);
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
