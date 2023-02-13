using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void PrintList(List<Student> students)
        {
            foreach (var item in students)
            {
                item.Show();
            }

        }
        static void Main(string[] args)
        {
            int[] arr = new int[] {85,34,65,97,90,96};
            //int[] filtered = new int[arr.Length];
            //int count = 0;
            //foreach (var item in arr)
            //{
            //    if(item>=80)
            //        filtered[count++] = item;   
            //}
            var filtered=(from int item in arr where item >=80 select item).ToArray();   
            List<Student> students = new List<Student>();  
            Random rand = new Random();
            for(int i = 1; i <= 100; i++)
            {
                students.Add(new Student()
                {
                    Id = i,
                    Name = "Student " + i,
                    Cgpa = rand.Next(10, 100)
                }); ;
            }
            PrintList(students);

            var passed = (from s in students
                         where s.Cgpa >=50
                         select s).ToList();
            Console.WriteLine("---------------*Passed"+passed.Count+"*-------------");
            PrintList(passed);
            var aplsfrst10= (from s in students
                            where s.Cgpa>=80 && s.Id>=1 && s.Id<=10
                            select s).ToList();
            Console.WriteLine("---------------*A+First10" + aplsfrst10.Count + "*-------------");
            PrintList(aplsfrst10);

        }
    }
}
