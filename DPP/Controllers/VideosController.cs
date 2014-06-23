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
    public class VideosController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Videos
        public ActionResult Index()
        {
            var videos = db.Videos.Include(v => v.Event).Include(v => v.Group).Include(v => v.Place).Include(v => v.Style).Include(v => v.User);
            return View(videos.ToList());
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address");
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoID,VideoName,Link,PlaceID,UserID,EventID,GroupID,StyleID,VideoDate")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Videos.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", video.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", video.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", video.PlaceID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", video.StyleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", video.UserID);
            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", video.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", video.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", video.PlaceID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", video.StyleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", video.UserID);
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoID,VideoName,Link,PlaceID,UserID,EventID,GroupID,StyleID,VideoDate")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", video.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", video.GroupID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", video.PlaceID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", video.StyleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", video.UserID);
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = db.Videos.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Video video = db.Videos.Find(id);
            db.Videos.Remove(video);
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
