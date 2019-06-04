using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class ApplicationsController : Controller
    {
        private DbModel db = new DbModel();

        [HttpGet]
        public ActionResult CreateApplication(int? tourId)
        {
            var tour = db.Tours.Where(x => x.Id == tourId).FirstOrDefault();
            if (tour != null)
            {
                Applications newApplication = new Applications();
                ViewBag.tourId = (int)tourId;
                ViewBag.tour = tour;
                return View(newApplication);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        public ActionResult CreateApplication(Applications application, int tourId)
        {
            var tour = db.Tours.Where(x => x.Id == tourId).FirstOrDefault();
            if(tour != null)
            {
                application.tour_id = tourId;
                application.order_date = System.DateTime.Now;
                db.Applications.Add(application);
                db.SaveChanges();
                ModelState.Clear();
                return View("CreateApplication");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
    }
}