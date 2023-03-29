using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = EmployeeService.Get();
            int a = 10;

        }
    }
}
