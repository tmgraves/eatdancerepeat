using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DPP.Models.ViewModel
{
    public class ProfileIndexViewModel
    {
        private DanceDBEntities _db = new DanceDBEntities();

        public ActionResult Index(string urlNameOrUserId)
        {
           
            if (String.IsNullOrWhiteSpace(urlNameOrUserId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }
    }
}