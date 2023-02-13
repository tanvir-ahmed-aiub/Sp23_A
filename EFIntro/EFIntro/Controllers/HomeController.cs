using EFIntro.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFIntro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration() {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Student model) {
            //if (ModelState.IsValid) { }
            //dbinsert
            var db = new StudentMs_AEntities();
            db.Students.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult List() {
            var db = new StudentMs_AEntities();
            var students = db.Students.ToList();
            return View(students);
        }
        public ActionResult Edit(int id) {
            var db = new StudentMs_AEntities();
            var student = (from s in db.Students
                          where s.Id == id
                          select s).SingleOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student updated) {
            var db = new StudentMs_AEntities();
            var extstudent = (from s in db.Students
                           where s.Id == updated.Id
                           select s).SingleOrDefault();
            extstudent.Name = updated.Name;
            extstudent.Profession = updated.Profession;
            extstudent.Gender = updated.Gender;
            extstudent.Dob = updated.Dob;
            db.SaveChanges();
            return RedirectToAction("List");
            //db.Entry(extstudent).CurrentValues.SetValues(updated);
            //db.Students.Remove(extstudent);

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