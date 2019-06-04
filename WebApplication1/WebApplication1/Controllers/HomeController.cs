using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private DbModel db = new DbModel();

        public ActionResult Index()
        {
            var tours = db.Tours.ToList();
            tours.Reverse();
            return View(tours);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TourFilter(string tourPrice)
        {

            if(tourPrice == "0-300")
            {
                var tours = db.Tours.Where(x => x.price < 300 && x.price > 0).ToList();
                return View("Index", tours);
            }
            if(tourPrice == "300-500")
            {
                var tours = db.Tours.Where(x => x.price < 500 && x.price > 300).ToList();
                return View("Index", tours);
            }
            if(tourPrice == "500-800")
            {
                var tours = db.Tours.Where(x => x.price < 800 && x.price > 500).ToList();
                return View("Index", tours);
            }
            if(tourPrice == "800+")
            {
                var tours = db.Tours.Where(x => x.price > 800).ToList();
                return View("Index", tours);
            }
            return View("Index");
        }
    }
}