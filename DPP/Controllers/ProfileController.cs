using DPP.Models;
using DPP.Models.ViewModel;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DPP.Controllers
{
    public class ProfileController : Controller
    {
        private DanceDBEntities _db = new DanceDBEntities();

        public ActionResult Index(string urlNameOrUserId)
        {
            if (String.IsNullOrWhiteSpace(urlNameOrUserId))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = _db.usp_Users_Search(null, null, urlNameOrUserId).FirstOrDefault();

            if(result == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var viewModel = new ProfileIndexViewModel();
            viewModel.FirstName = result.FirstName;
            viewModel.LastName = result.LastName;

            return View(viewModel);
        }
    }
}