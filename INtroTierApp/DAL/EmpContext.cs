using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmpContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
