using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.IO;

namespace WebApplication1.Controllers
{

    public class ToursController : Controller
    {

        private DbModel db = new DbModel();

        [HttpGet]
        public ActionResult ViewTour(int? tourId )
        {
            var tour = db.Tours.Find(tourId);
            if (tour != null)
            {
                return View(tour);
            }
            return View("Index", "Home");
        }

        [HttpGet]
        public ActionResult CreateTour()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTour(Tours newTour, HttpPostedFileBase tour_img)
        {
            string fileName = System.IO.Path.GetFileName(tour_img.FileName);
            newTour.img_path = "/Files/" + fileName;
            tour_img.SaveAs(Server.MapPath("~/Files/" + fileName));
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
                    var tourToDelete = db.Tours.Find(tourId);
                    if (tourToDelete != null)
                    {
                        db.Tours.Remove(tourToDelete);
                        db.SaveChanges();
                        ViewBag.SuccessMessage = "Tour deleted successfully";
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }


        
    }
}