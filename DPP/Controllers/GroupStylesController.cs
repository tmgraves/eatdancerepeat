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
    public class GroupStylesController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: GroupStyles
        public ActionResult Index()
        {
            var groupStyles = db.GroupStyles.Include(g => g.Group).Include(g => g.Style);
            return View(groupStyles.ToList());
        }

        // GET: GroupStyles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStyle groupStyle = db.GroupStyles.Find(id);
            if (groupStyle == null)
            {
                return HttpNotFound();
            }
            return View(groupStyle);
        }

        // GET: GroupStyles/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1");
            return View();
        }

        // POST: GroupStyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupStyleID,GroupID,StyleID")] GroupStyle groupStyle)
        {
            if (ModelState.IsValid)
            {
                db.GroupStyles.Add(groupStyle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupStyle.GroupID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", groupStyle.StyleID);
            return View(groupStyle);
        }

        // GET: GroupStyles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStyle groupStyle = db.GroupStyles.Find(id);
            if (groupStyle == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupStyle.GroupID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", groupStyle.StyleID);
            return View(groupStyle);
        }

        // POST: GroupStyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupStyleID,GroupID,StyleID")] GroupStyle groupStyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupStyle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", groupStyle.GroupID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", groupStyle.StyleID);
            return View(groupStyle);
        }

        // GET: GroupStyles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupStyle groupStyle = db.GroupStyles.Find(id);
            if (groupStyle == null)
            {
                return HttpNotFound();
            }
            return View(groupStyle);
        }

        // POST: GroupStyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupStyle groupStyle = db.GroupStyles.Find(id);
            db.GroupStyles.Remove(groupStyle);
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
