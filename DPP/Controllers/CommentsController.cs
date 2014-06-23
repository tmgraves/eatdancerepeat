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
    public class CommentsController : Controller
    {
        private DanceDBEntities db = new DanceDBEntities();

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Event).Include(c => c.Group).Include(c => c.Picture).Include(c => c.Place).Include(c => c.Style).Include(c => c.User).Include(c => c.Video);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName");
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address");
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName");
            ViewBag.VideoID = new SelectList(db.Videos, "VideoID", "VideoName");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,UserID,PlaceID,EventID,GroupID,PictureID,VideoID,StyleID,Comment1,CommentDateTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", comment.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", comment.GroupID);
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName", comment.PictureID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", comment.PlaceID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", comment.StyleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", comment.UserID);
            ViewBag.VideoID = new SelectList(db.Videos, "VideoID", "VideoName", comment.VideoID);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", comment.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", comment.GroupID);
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName", comment.PictureID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", comment.PlaceID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", comment.StyleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", comment.UserID);
            ViewBag.VideoID = new SelectList(db.Videos, "VideoID", "VideoName", comment.VideoID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,UserID,PlaceID,EventID,GroupID,PictureID,VideoID,StyleID,Comment1,CommentDateTime")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", comment.EventID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", comment.GroupID);
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName", comment.PictureID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Address", comment.PlaceID);
            ViewBag.StyleID = new SelectList(db.Styles, "StyleID", "Style1", comment.StyleID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FirstName", comment.UserID);
            ViewBag.VideoID = new SelectList(db.Videos, "VideoID", "VideoName", comment.VideoID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
