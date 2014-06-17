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
    public class ReviewsController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Event).Include(r => r.Place).Include(r => r.User).Include(r => r.User1);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType");
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceType");
            ViewBag.AuthorUserID = new SelectList(db.Users, "UserID", "FirstName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,AuthorUserID,Review1,ReviewDate,Stars,EventID,UserID,PlaceID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", review.EventID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceType", review.PlaceID);
            ViewBag.AuthorUserID = new SelectList(db.Users, "UserID", "FirstName", review.AuthorUserID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", review.UserID);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", review.EventID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceType", review.PlaceID);
            ViewBag.AuthorUserID = new SelectList(db.Users, "UserID", "FirstName", review.AuthorUserID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", review.UserID);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,AuthorUserID,Review1,ReviewDate,Stars,EventID,UserID,PlaceID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType", review.EventID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "PlaceType", review.PlaceID);
            ViewBag.AuthorUserID = new SelectList(db.Users, "UserID", "FirstName", review.AuthorUserID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", review.UserID);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
