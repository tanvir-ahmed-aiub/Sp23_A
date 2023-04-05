using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CourseRepo : Repo, IRepo<Course, int, bool>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Course> Get()
        {
            return db.Courses.ToList();
        }

        public Course Get(int id)
        {
            return db.Courses.Find(id);
        }

        public bool Insert(Course obj)
        {
            db.Courses.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Course obj)
        {
            throw new NotImplementedException();
        }
    }
}
