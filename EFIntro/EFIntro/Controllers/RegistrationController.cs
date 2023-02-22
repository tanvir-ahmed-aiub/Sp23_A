using EFIntro.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFIntro.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            Session["Name"] = "Tanvir";
            StudentMs_AEntities db = new StudentMs_AEntities();

            return View(db.Courses.ToList());
        }
        public ActionResult Enroll(int id)
        {
            StudentMs_AEntities db = new StudentMs_AEntities();
            var excrs = (from c in db.Courses
                         where c.Id == id
                         select c).SingleOrDefault();
            if(excrs.CourseStudents.Count < 10) { 
                Random rnd = new Random();
                var data = new CourseStudent();
                data.CourseId = id;
                data.StId = rnd.Next(1,6);
                db.CourseStudents.Add(data);
                db.SaveChanges();
                TempData["Msg"] = "Successfull Added ";
            }
            else
            {
                TempData["Msg"]="Section Full for "+excrs.Name;
            }
            return RedirectToAction("Index");


        }
    }
}