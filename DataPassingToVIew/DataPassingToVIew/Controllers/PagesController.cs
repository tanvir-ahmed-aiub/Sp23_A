using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataPassingToVIew.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Home() { 
            return View();
        }
        public ActionResult About() {
            return View();
        }
        public ActionResult Contact() {
            return View();
        }
        public ActionResult Login() {

            return View();
        }
        public ActionResult LoginSubmit() {
            TempData["msg"] = "Login Successful";
            return RedirectToAction("Index", "Dashobard");
        }
        public ActionResult SignUp() {
            return View();
        }

    }
}