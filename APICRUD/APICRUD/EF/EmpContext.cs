using APICRUD.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APICRUD.EF
{
    public class EmpContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}