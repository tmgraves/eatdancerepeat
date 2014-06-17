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
    public class EventMembersController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: EventMembers
        public ActionResult Index()
        {
            var eventMembers = db.EventMembers.Include(e => e.Event).Include(e => e.User);
            return View(eventMembers.ToList());
        }

        // GET: EventMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMember eventMember = db.EventMembers.Find(id);
            if (eventMember == null)
            {
                return HttpNotFound();
            }
            return View(eventMember);
        }

        // GET: EventMembers/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: EventMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventMemberID,EventID,UserID,AttendeeStatus,Organizer,JoinDate")] EventMember eventMember)
        {
            if (ModelState.IsValid)
            {
                db.EventMembers.Add(eventMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", eventMember.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", eventMember.UserID);
            return View(eventMember);
        }

        // GET: EventMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMember eventMember = db.EventMembers.Find(id);
            if (eventMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", eventMember.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", eventMember.UserID);
            return View(eventMember);
        }

        // POST: EventMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventMemberID,EventID,UserID,AttendeeStatus,Organizer,JoinDate")] EventMember eventMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", eventMember.EventID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", eventMember.UserID);
            return View(eventMember);
        }

        // GET: EventMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMember eventMember = db.EventMembers.Find(id);
            if (eventMember == null)
            {
                return HttpNotFound();
            }
            return View(eventMember);
        }

        // POST: EventMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventMember eventMember = db.EventMembers.Find(id);
            db.EventMembers.Remove(eventMember);
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
