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
    public class TeamMembersController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: TeamMembers
        public ActionResult Index()
        {
            var teamMembers = db.TeamMembers.Include(t => t.Team).Include(t => t.User);
            return View(teamMembers.ToList());
        }

        // GET: TeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // GET: TeamMembers/Create
        public ActionResult Create()
        {
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: TeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamMemberID,TeamID,UserID,JoinDate,Coach")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                db.TeamMembers.Add(teamMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", teamMember.TeamID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", teamMember.UserID);
            return View(teamMember);
        }

        // GET: TeamMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", teamMember.TeamID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", teamMember.UserID);
            return View(teamMember);
        }

        // POST: TeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamMemberID,TeamID,UserID,JoinDate,Coach")] TeamMember teamMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamID = new SelectList(db.Teams, "TeamID", "TeamName", teamMember.TeamID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", teamMember.UserID);
            return View(teamMember);
        }

        // GET: TeamMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMember teamMember = db.TeamMembers.Find(id);
            if (teamMember == null)
            {
                return HttpNotFound();
            }
            return View(teamMember);
        }

        // POST: TeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamMember teamMember = db.TeamMembers.Find(id);
            db.TeamMembers.Remove(teamMember);
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
