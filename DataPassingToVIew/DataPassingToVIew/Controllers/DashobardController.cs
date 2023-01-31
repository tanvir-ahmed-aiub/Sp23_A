using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataPassingToVIew.Controllers
{
    public class DashobardController : Controller
    {
        // GET: Dashobard
        public ActionResult Index() { 
            return View(); ;
        }
        public ActionResult MyProfile() {
            
            ViewBag.Section = "A";
            ViewBag.Students = 41;

            ViewData["InsName"] = "Ahmed";
            ViewBag.InsName = "Tanvir"; ;
            string[] names = { "Samiha", "Rouf", "ifaj", "Tamim", "Paul" };
            ViewBag.Names = names;
            return View();
        }
        public ActionResult Settings() {
            return View();
        }
        public ActionResult Logout() {
            return View();
        }
    }
}