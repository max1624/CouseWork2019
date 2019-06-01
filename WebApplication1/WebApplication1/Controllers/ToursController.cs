using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ToursController : Controller
    {
        // GET: Tours
        [HttpGet]
        public ActionResult CreateTour()
        {
            return View();
        }
    }
}