using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> Get() {
            
            var data = DataAccessFactory.EmployeeData().Get();
            return Convert(data);

        }
        public static List<EmployeeDTO> Get10() {
            var emps = DataAccessFactory.EmployeeData().Get();
            var data = (from e in emps
                       where e.Id < 11
                       select e).ToList();
            return Convert(data);
        }
        public static EmployeeDTO Get(int id) { 
            return Convert(DataAccessFactory.EmployeeData().Get(id));
        }
        public static bool Create(EmployeeDTO employee) { 
            var data = Convert(employee);
            var res =DataAccessFactory.EmployeeData().Insert(data);

            if (res != null) return true;
            return false;
        }
        public static bool Update(EmployeeDTO employee) {
            var data = Convert(employee);
            var res = DataAccessFactory.EmployeeData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id) { 
            return DataAccessFactory.EmployeeData().Delete(id);
        }

         static List<EmployeeDTO> Convert(List<Employee> employees) {
            var data = new List<EmployeeDTO>();
            foreach (var employee in employees) {
                data.Add(Convert(employee));
            }
            return data;

        }
        static Employee Convert(EmployeeDTO emp) {
            return new Employee()
            {
                Id = emp.Id,
                Name = emp.Name
            };
        }
        static EmployeeDTO Convert(Employee emp) { 
            return new EmployeeDTO()
            {
                Id = emp.Id,
                Name = emp.Name
            };
        }

    }
}
