using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeRepoV2 : Repo, IRepo<Employee, int, Employee>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public Employee Insert(Employee obj)
        {
            db.Employees.Add(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
            
        }

        public Employee Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
