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
    public class OpenHousesController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: OpenHouses
        public ActionResult Index()
        {
            var events = db.Events.Include(o => o.Group);
            return View(events.OfType<OpenHouse>());
        }

        // GET: OpenHouses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenHouse openHouse = db.Events.OfType<OpenHouse>().Single(o => o.EventID == id);
            if (openHouse == null)
            {
                return HttpNotFound();
            }
            return View(openHouse);
        }

        // GET: OpenHouses/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            return View();
        }

        // POST: OpenHouses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,StartTime,EndTime,AllDay,Link,Cost,LocationType,Address,Address2,City,State,Zip,Country,ParentEventID,Frequency,DaysOfWeek,GroupID")] OpenHouse openHouse)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(openHouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", openHouse.GroupID);
            return View(openHouse);
        }

        // GET: OpenHouses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenHouse openHouse = db.Events.OfType<OpenHouse>().Single(o => o.EventID == id);
            if (openHouse == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", openHouse.GroupID);
            return View(openHouse);
        }

        // POST: OpenHouses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventName,Description,StartDate,EndDate,StartTime,EndTime,AllDay,Link,Cost,LocationType,Address,Address2,City,State,Zip,Country,ParentEventID,Frequency,DaysOfWeek,GroupID")] OpenHouse openHouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openHouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", openHouse.GroupID);
            return View(openHouse);
        }

        // GET: OpenHouses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenHouse openHouse = db.Events.OfType<OpenHouse>().Single(o => o.EventID == id);
            if (openHouse == null)
            {
                return HttpNotFound();
            }
            return View(openHouse);
        }

        // POST: OpenHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpenHouse openHouse = db.Events.OfType<OpenHouse>().Single(o => o.EventID == id);
            db.Events.Remove(openHouse);
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
