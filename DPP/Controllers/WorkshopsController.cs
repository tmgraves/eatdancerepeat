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
    public class WorkshopsController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Workshops
        public ActionResult Index()
        {
            var events = db.Events.Include(w => w.Group);
            return View(events.OfType<Workshop>());
        }

        // GET: Workshops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Events.OfType<Workshop>().Single(w => w.EventID == id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        // GET: Workshops/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            return View();
        }

        // POST: Workshops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,StartTime,EndTime,AllDay,Link,Cost,LocationType,Address,Address2,City,State,Zip,Country,ParentEventID,Frequency,DaysOfWeek,GroupID")] Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(workshop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", workshop.GroupID);
            return View(workshop);
        }

        // GET: Workshops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Events.OfType<Workshop>().Single(w => w.EventID == id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", workshop.GroupID);
            return View(workshop);
        }

        // POST: Workshops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,StartTime,EndTime,AllDay,Link,Cost,LocationType,Address,Address2,City,State,Zip,Country,ParentEventID,Frequency,DaysOfWeek,GroupID")] Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workshop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", workshop.GroupID);
            return View(workshop);
        }

        // GET: Workshops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workshop workshop = db.Events.OfType<Workshop>().Single(w => w.EventID == id);
            if (workshop == null)
            {
                return HttpNotFound();
            }
            return View(workshop);
        }

        // POST: Workshops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workshop workshop = db.Events.OfType<Workshop>().Single(w => w.EventID == id);
            db.Events.Remove(workshop);
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
