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
    public class SocialsController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Socials
        public ActionResult Index()
        {
            var events = db.Events.Include(s => s.Group);
            return View(events.OfType<Social>());
        }

        // GET: Socials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = db.Events.OfType<Social>().Single(s => s.EventID == id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // GET: Socials/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            return View();
        }

        // POST: Socials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,StartTime,EndTime,AllDay,Link,Cost,LocationType,Address,Address2,City,State,Zip,Country,ParentEventID,Frequency,DaysOfWeek,GroupID")] Social social)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(social);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", social.GroupID);
            return View(social);
        }

        // GET: Socials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = db.Events.OfType<Social>().Single(s => s.EventID == id);
            if (social == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", social.GroupID);
            return View(social);
        }

        // POST: Socials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,StartTime,EndTime,AllDay,Link,Cost,LocationType,Address,Address2,City,State,Zip,Country,ParentEventID,Frequency,DaysOfWeek,GroupID")] Social social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", social.GroupID);
            return View(social);
        }

        // GET: Socials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = db.Events.OfType<Social>().Single(s => s.EventID == id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // POST: Socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Social social = db.Events.OfType<Social>().Single(s => s.EventID == id);
            db.Events.Remove(social);
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
