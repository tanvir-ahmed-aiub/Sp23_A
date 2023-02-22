using EFIntro.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFIntro.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult List()
        {
            StudentMs_AEntities db = new StudentMs_AEntities();

            return View(db.Students.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student data) {
            StudentMs_AEntities db = new StudentMs_AEntities();
            db.Students.Add(data);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Details(int id) {
            StudentMs_AEntities db = new StudentMs_AEntities();
            var st = from s in db.Students
                     where s.Id == id
                     select s;
            return View(st.SingleOrDefault());
        }
    }
}