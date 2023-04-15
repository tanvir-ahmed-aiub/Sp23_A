using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LoginRepo : Repo, IRepo<Login, string, Login>,IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            var user = (from u in db.Logins
                       where u.Username.Equals(username)
                       && u.Password.Equals(password)
                       select u).SingleOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;

        }
        
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Login> Get()
        {
            throw new NotImplementedException();
        }

        public Login Get(string id)
        {
            return db.Logins.Find(id);
        }

        public Login Insert(Login obj)
        {
            db.Logins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Login Update(Login obj)
        {
            throw new NotImplementedException();
        }
    }
}
