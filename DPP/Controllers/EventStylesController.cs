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
    public class EventStylesController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: EventStyles
        public ActionResult Index()
        {
            var eventStyles = db.EventStyles.Include(e => e.Event).Include(e => e.Style);
            return View(eventStyles.ToList());
        }

        // GET: EventStyles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventStyle eventStyle = db.EventStyles.Find(id);
            if (eventStyle == null)
            {
                return HttpNotFound();
            }
            return View(eventStyle);
        }

        // GET: EventStyles/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1");
            return View();
        }

        // POST: EventStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventStyleID,EventID,StyleID")] EventStyle eventStyle)
        {
            if (ModelState.IsValid)
            {
                db.EventStyles.Add(eventStyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventStyle.EventID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", eventStyle.StyleID);
            return View(eventStyle);
        }

        // GET: EventStyles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventStyle eventStyle = db.EventStyles.Find(id);
            if (eventStyle == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventStyle.EventID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", eventStyle.StyleID);
            return View(eventStyle);
        }

        // POST: EventStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventStyleID,EventID,StyleID")] EventStyle eventStyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventStyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", eventStyle.EventID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", eventStyle.StyleID);
            return View(eventStyle);
        }

        // GET: EventStyles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventStyle eventStyle = db.EventStyles.Find(id);
            if (eventStyle == null)
            {
                return HttpNotFound();
            }
            return View(eventStyle);
        }

        // POST: EventStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventStyle eventStyle = db.EventStyles.Find(id);
            db.EventStyles.Remove(eventStyle);
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
