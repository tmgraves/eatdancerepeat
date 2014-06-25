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
    public class DancersController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Dancers
        public ActionResult Index()
        {
            var dancers = db.Dancers.Include(d => d.User);
            return View(dancers.ToList());
        }

        // GET: Dancers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dancer dancer = db.Dancers.Find(id);
            if (dancer == null)
            {
                return HttpNotFound();
            }
            return View(dancer);
        }

        // GET: Dancers/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Dancers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,StartDate")] Dancer dancer)
        {
            if (ModelState.IsValid)
            {
                db.Dancers.Add(dancer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", dancer.UserID);
            return View(dancer);
        }

        // GET: Dancers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dancer dancer = db.Dancers.Find(id);
            if (dancer == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", dancer.UserID);
            return View(dancer);
        }

        // POST: Dancers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,StartDate")] Dancer dancer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dancer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", dancer.UserID);
            return View(dancer);
        }

        // GET: Dancers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dancer dancer = db.Dancers.Find(id);
            if (dancer == null)
            {
                return HttpNotFound();
            }
            return View(dancer);
        }

        // POST: Dancers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dancer dancer = db.Dancers.Find(id);
            db.Dancers.Remove(dancer);
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
