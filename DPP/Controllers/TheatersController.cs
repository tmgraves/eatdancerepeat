﻿using System;
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
    public class TheatersController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Theaters
        public ActionResult Index()
        {
            return View(db.Places.OfType<Theater>());
        }

        // GET: Theaters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theater theater = db.Places.OfType<Theater>().Single(t => t.PlaceID == id);
            if (theater == null)
            {
                return HttpNotFound();
            }
            return View(theater);
        }

        // GET: Theaters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Theaters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaceID,Address,Address2,City,State,Zip,Country")] Theater theater)
        {
            if (ModelState.IsValid)
            {
                db.Places.Add(theater);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theater);
        }

        // GET: Theaters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theater theater = db.Places.OfType<Theater>().Single(t => t.PlaceID == id);
            if (theater == null)
            {
                return HttpNotFound();
            }
            return View(theater);
        }

        // POST: Theaters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaceID,Address,Address2,City,State,Zip,Country")] Theater theater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theater);
        }

        // GET: Theaters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Theater theater = db.Places.OfType<Theater>().Single(t => t.PlaceID == id);
            if (theater == null)
            {
                return HttpNotFound();
            }
            return View(theater);
        }

        // POST: Theaters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Theater theater = db.Places.OfType<Theater>().Single(t => t.PlaceID == id);
            db.Places.Remove(theater);
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
