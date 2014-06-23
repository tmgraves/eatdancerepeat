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
    public class GroupMembersController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: GroupMembers
        public ActionResult Index()
        {
            var groupMembers = db.GroupMembers.Include(g => g.Group).Include(g => g.User);
            return View(groupMembers.ToList());
        }

        // GET: GroupMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMember groupMember = db.GroupMembers.Find(id);
            if (groupMember == null)
            {
                return HttpNotFound();
            }
            return View(groupMember);
        }

        // GET: GroupMembers/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: GroupMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupMemberID,GroupID,UserID,JoinDate,Admin")] GroupMember groupMember)
        {
            if (ModelState.IsValid)
            {
                db.GroupMembers.Add(groupMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupMember.GroupID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", groupMember.UserID);
            return View(groupMember);
        }

        // GET: GroupMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMember groupMember = db.GroupMembers.Find(id);
            if (groupMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupMember.GroupID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", groupMember.UserID);
            return View(groupMember);
        }

        // POST: GroupMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupMemberID,GroupID,UserID,JoinDate,Admin")] GroupMember groupMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupMember.GroupID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", groupMember.UserID);
            return View(groupMember);
        }

        // GET: GroupMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMember groupMember = db.GroupMembers.Find(id);
            if (groupMember == null)
            {
                return HttpNotFound();
            }
            return View(groupMember);
        }

        // POST: GroupMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupMember groupMember = db.GroupMembers.Find(id);
            db.GroupMembers.Remove(groupMember);
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
