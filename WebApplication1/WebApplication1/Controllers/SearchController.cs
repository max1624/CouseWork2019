using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        DbModel db = new DbModel();
        [HttpPost]
        public ActionResult Search(string search)
        {
            var tours = (from m in db.Tours
                          where m.name.ToLower().StartsWith(search.ToLower())
                          select m).ToList();
            ViewBag.search = search;
            if(tours != null)
            {
                bool isEmpty = (tours.Count > 0) ? false : true;
                if (isEmpty)
                {
                    ViewBag.NoResults = "No results for your search.";
                }
            }
            return View(tours);
        }
    }
}