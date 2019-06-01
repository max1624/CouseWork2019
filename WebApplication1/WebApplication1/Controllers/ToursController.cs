using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{



    public class ToursController : Controller
    {

        private DbModel db = new DbModel();

        // GET: Tours
        [HttpGet]
        public ActionResult CreateTour()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTour(Tours newTour)
        {
            db.Tours.Add(newTour);
            db.SaveChanges();
            ViewBag.SuccessMessage = "Tour created successfuly";
            return View(newTour);
        }
        [HttpGet]
        public ActionResult DeleteTour(int? tourId)
        {
            if (Session["userId"] != null)
            {
                if (tourId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                using (DbModel db = new DbModel())
                {
                    var postToDelete = db.Tours.Find(tourId);
                    if (postToDelete != null)
                    {
                        db.Tours.Remove(postToDelete);
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Post deleted successfully";
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}