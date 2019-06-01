using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            Users userModel = new Users();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Register(Users newUser)
        {
            using (DbModel db = new DbModel())
            {
                if (db.Users.Any(x => x.email == newUser.email))
                {
                    ViewBag.DuplicateMessage = "User with this e-mail already exists";
                }
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration successfull";
            return View("Register", new Users());
        }

        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            Users userModel = new Users();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Login(Users visitor)
        {
            using (DbModel db = new DbModel())
            {
                var user = db.Users.Where(x => x.email == visitor.email && x.password == visitor.password).FirstOrDefault();
                if (user != null)
                {
                    Session["userId"] = user.Id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "E-mail or password is incorrect!";
                    return View("Login", visitor);
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Users");
        }
    }
}