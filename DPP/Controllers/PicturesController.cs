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
    public class PicturesController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Pictures
        public ActionResult Index()
        {
            var pictures = db.Pictures.Include(p => p.Event).Include(p => p.Group).Include(p => p.Place).Include(p => p.User).Include(p => p.User1);
            return View(pictures.ToList());
        }

        // GET: Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Pictures/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            ViewBag.PostUserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PictureID,PictureName,PostUserID,UserID,PlaceID,EventID,GroupID,Link,PictureDate")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", picture.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", picture.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", picture.PlaceID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", picture.UserID);
            ViewBag.PostUserID = new SelectList(db.Users, "UserID", "FirstName", picture.PostUserID);
            return View(picture);
        }

        // GET: Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", picture.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", picture.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", picture.PlaceID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", picture.UserID);
            ViewBag.PostUserID = new SelectList(db.Users, "UserID", "FirstName", picture.PostUserID);
            return View(picture);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PictureID,PictureName,PostUserID,UserID,PlaceID,EventID,GroupID,Link,PictureDate")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", picture.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", picture.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", picture.PlaceID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", picture.UserID);
            ViewBag.PostUserID = new SelectList(db.Users, "UserID", "FirstName", picture.PostUserID);
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
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
