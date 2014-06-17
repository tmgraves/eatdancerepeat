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
    public class TeamEventsController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: TeamEvents
        public ActionResult Index()
        {
            var teamEvents = db.TeamEvents.Include(t => t.Event).Include(t => t.Team);
            return View(teamEvents.ToList());
        }

        // GET: TeamEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamEvent teamEvent = db.TeamEvents.Find(id);
            if (teamEvent == null)
            {
                return HttpNotFound();
            }
            return View(teamEvent);
        }

        // GET: TeamEvents/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType");
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName");
            return View();
        }

        // POST: TeamEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamEventID,TeamID,EventID")] TeamEvent teamEvent)
        {
            if (ModelState.IsValid)
            {
                db.TeamEvents.Add(teamEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", teamEvent.EventID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", teamEvent.TeamID);
            return View(teamEvent);
        }

        // GET: TeamEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamEvent teamEvent = db.TeamEvents.Find(id);
            if (teamEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", teamEvent.EventID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", teamEvent.TeamID);
            return View(teamEvent);
        }

        // POST: TeamEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamEventID,TeamID,EventID")] TeamEvent teamEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", teamEvent.EventID);
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", teamEvent.TeamID);
            return View(teamEvent);
        }

        // GET: TeamEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamEvent teamEvent = db.TeamEvents.Find(id);
            if (teamEvent == null)
            {
                return HttpNotFound();
            }
            return View(teamEvent);
        }

        // POST: TeamEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamEvent teamEvent = db.TeamEvents.Find(id);
            db.TeamEvents.Remove(teamEvent);
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
