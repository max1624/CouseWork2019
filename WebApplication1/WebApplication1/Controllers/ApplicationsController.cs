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
                return View(newApplication);
            }
        }
        [HttpPost]
        public ActionResult CreateAppliction(int? tourId)
        {
            return View();
        }
    }
}