using EFCodeFirst.Auth;
using EFCodeFirst.EF;
using EFCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirst.Controllers
{
    [Logged]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login() {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel login) {
            if (ModelState.IsValid) { 
                PMSDb db = new PMSDb();
                var user = (from u in db.Users
                            where u.Username.Equals(login.Username)
                            && u.Password.Equals(login.Password)
                            select u).SingleOrDefault();
                if (user != null) {
                    Session["user"] = user;
                    var retUrl = Request["ReturnUrl"];
                    if (retUrl != null) {
                        return Redirect(retUrl);
                    }
                    return RedirectToAction("Index", "Order");
                }
            }
            TempData["Msg"] = "Username Password invalid";
            return View(login);
        }

        public ActionResult Logout() {
            return null;
        }
        public ActionResult Index()
        {
            
            return View();
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
    }
}