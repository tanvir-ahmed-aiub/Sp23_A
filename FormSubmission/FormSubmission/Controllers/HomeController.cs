using FormSubmission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Index(FormCollection forms) {
        //public ActionResult Index(string Uname, string Pass)
        public ActionResult Index(Login obj)
        {
            //ViewBag.Uname = Request["Uname"];
            //ViewBag.Pass = Request["Pass"];

            //ViewBag.Uname = forms["Uname"];
            //ViewBag.Pass = forms["Pass"];

           // ViewBag.Uname = Uname;
            //ViewBag.Pass = Pass;
            //ViewBag.Login = obj;

            return View(obj);
        }

        public ActionResult About()
        {
           List<Student> students = new List<Student>();
            Random random = new Random();
            for (int i = 1; i <= 100; i++) { 
                /*Student student = new Student();
                student.Name = "Student " + i;
                student.Id = "Id-" + i;
                student.Roll = i;
                students.Add(student);*/

                students.Add(new Student() { 
                    Id = "Id-"+i,
                    Name = "Student "+random.Next(100,500),
                    Roll = i
                });
            }


            return View(students);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}