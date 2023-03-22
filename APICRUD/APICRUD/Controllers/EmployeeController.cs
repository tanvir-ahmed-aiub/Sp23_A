using APICRUD.EF;
using APICRUD.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICRUD.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("api/employees")]
        public HttpResponseMessage AllEmpolyees() {
            EmpContext db = new EmpContext();
            var data = db.Employees.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/employees/{id}")]
        public HttpResponseMessage GetEmployee(int id) {
            EmpContext db = new EmpContext();
            var data = db.Employees.Find(id);
            if (data != null) {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        [HttpPost]
        [Route("api/employees/update")]
        public HttpResponseMessage UpdateEmployee(Employee employee) {
            EmpContext db = new EmpContext();

            //var e = new  { Msg="Ok" };
            var exemp = db.Employees.Find(employee.Id);
            if (exemp != null) {
                db.Entry(exemp).CurrentValues.SetValues(employee);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,new { Msg = "updated",Data=employee});
            }
            return Request.CreateResponse(HttpStatusCode.NotFound,new { Msg = "Employee Id not Found, Failed to Update", Data = employee });

        }
    }
}
