using BLL.DTOs;
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
            var data = EmployeeRepo.Get();
            return Convert(data);

        }
        public static List<EmployeeDTO> Get10() {
            var data = (from e in EmployeeRepo.Get()
                       where e.Id < 11
                       select e).ToList();
            return Convert(data);
        }
        public static EmployeeDTO Get(int id) { 
            return Convert(EmployeeRepo.Get(id));
        }
        public static bool Create(EmployeeDTO employee) { 
            var data = Convert(employee);
            return EmployeeRepo.Create(data);
        }
        public static bool Update(EmployeeDTO employee) {
            var data = Convert(employee);
            return EmployeeRepo.Update(data);
        }
        public static bool Delete(int id) { 
            return EmployeeRepo.Delete(id);
        }

         static List<EmployeeDTO> Convert(List<Employee> employees) {
            var data = new List<EmployeeDTO>();
            foreach (var employee in employees) {
                data.Add(new EmployeeDTO() { 
                    Id = employee.Id,
                    Name = employee.Name
                });
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
