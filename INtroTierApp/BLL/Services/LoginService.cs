using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LoginService
    {
        public static bool Authenticate(string uname, string pass) { 
            var res = DataAccessFactory.AuthData().Authenticate(uname, pass);
            return res;
        }
    }
}
