using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace INtroTierApp.Controllers
{
    [EnableCors("*","*","*")]
    public class EmpController : ApiController
    {
        [HttpGet]
        [Route("api/employees")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = EmployeeService.Get();
                return Request.CreateResponse(HttpStatusCode.OK,data);
            }
            catch (Exception ex) { 
            
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                
            }
        }
        [HttpGet]
        [Route("api/employees/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, EmployeeService.Get(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
        [HttpPost]
        [Route("api/employees/add")]
        public HttpResponseMessage Add(EmployeeDTO emp)
        {
            try
            {
                var res = EmployeeService.Create(emp);
                if (res)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", Data = emp });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Not Inserted", Data = emp });
                }
            }
            catch (Exception ex) {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message, Data = emp });
            }
        }
    }
}
