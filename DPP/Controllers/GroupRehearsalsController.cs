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
    public class GroupRehearsalsController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: GroupRehearsals
        public ActionResult Index()
        {
            var groupRehearsals = db.GroupRehearsals.Include(g => g.Group).Include(g => g.Place);
            return View(groupRehearsals.ToList());
        }

        // GET: GroupRehearsals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupRehearsal groupRehearsal = db.GroupRehearsals.Find(id);
            if (groupRehearsal == null)
            {
                return HttpNotFound();
            }
            return View(groupRehearsal);
        }

        // GET: GroupRehearsals/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address");
            return View();
        }

        // POST: GroupRehearsals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupRehearsalID,GroupID,PlaceID,Day,Time")] GroupRehearsal groupRehearsal)
        {
            if (ModelState.IsValid)
            {
                db.GroupRehearsals.Add(groupRehearsal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupRehearsal.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", groupRehearsal.PlaceID);
            return View(groupRehearsal);
        }

        // GET: GroupRehearsals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupRehearsal groupRehearsal = db.GroupRehearsals.Find(id);
            if (groupRehearsal == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupRehearsal.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", groupRehearsal.PlaceID);
            return View(groupRehearsal);
        }

        // POST: GroupRehearsals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupRehearsalID,GroupID,PlaceID,Day,Time")] GroupRehearsal groupRehearsal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupRehearsal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupRehearsal.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", groupRehearsal.PlaceID);
            return View(groupRehearsal);
        }

        // GET: GroupRehearsals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupRehearsal groupRehearsal = db.GroupRehearsals.Find(id);
            if (groupRehearsal == null)
            {
                return HttpNotFound();
            }
            return View(groupRehearsal);
        }

        // POST: GroupRehearsals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupRehearsal groupRehearsal = db.GroupRehearsals.Find(id);
            db.GroupRehearsals.Remove(groupRehearsal);
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
