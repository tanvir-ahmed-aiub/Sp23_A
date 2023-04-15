using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeRepo : Repo, IRepo<Employee, int, Employee>,IAuth<bool>
    {
        public bool Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        /*static EmpContext empContext;
static EmployeeRepo() { 
   empContext = new EmpContext();
}
public static List<Employee> Get() {
   //var employees = new List<Employee>();
   //for (int i = 1; i <= 12; i++)
   //{
   //    employees.Add(new Employee { Id = i, Name = "E-" + 1 });
   //}
   //return employees;
   return empContext.Employees.ToList();
}
public static Employee Get(int id) {
   return empContext.Employees.Find(id);
}
public static bool Create(Employee employee) { 
   empContext.Employees.Add(employee);
   return empContext.SaveChanges() > 0;
}
public static bool Update(Employee employee) {
   var exemp = empContext.Employees.Find(employee.Id);
   empContext.Entry(exemp).CurrentValues.SetValues(employee);
   return empContext.SaveChanges() > 0;
}
public static bool Delete(int id) {
   var exemp = Get(id);
   empContext.Employees.Remove(exemp);
   return empContext.SaveChanges() > 0;
}*/
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
            throw new NotImplementedException();
        }

        public Employee Update(Employee obj)
        {
            throw new NotImplementedException();
        }
    }
}
