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
            if(tourId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Applications newApplication = new Applications();
                ViewBag.tourId = (int)tourId;
                return View(newApplication);
            }
        }
        [HttpPost]
        public ActionResult CreateApplication(Applications application, int tourId)
        {
            //TODO: check if tour with this id exists
            application.tour_id = tourId;
            application.order_date = System.DateTime.Now;
            db.Applications.Add(application);
            db.SaveChanges();
            ModelState.Clear();
            return View("CreateApplication");
        }
    }
}