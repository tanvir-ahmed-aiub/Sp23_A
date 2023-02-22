using EFIntro.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFIntro.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult List()
        {
            StudentMs_AEntities db = new StudentMs_AEntities();
            return View(db.Departments.ToList());
        }
        public ActionResult Details(int id)
        {
            StudentMs_AEntities db = new StudentMs_AEntities();
            var extd = from d in db.Departments
                       where d.Id == id
                       select d;
            return View(extd.SingleOrDefault());

        }
    }
}