using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    public class StudentController : ApiController
    {
        public List<string> Get()
        {
            var names =  new string[] { "Shafiat", "Rawaha", "Sani", "Mim", "Sufian" };
            return names.ToList();
        }
        public List<string> Post()
        {
            var names = new string[] { "Shafiat", "Rawaha", "Sani", "Mim", "Sufian" };
            return names.ToList();
        }
    }
}
