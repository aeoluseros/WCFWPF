using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst {
    public enum Level: byte
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    class Program {
        static void Main(string[] args)
        {
            var dbContext = new PlutoDbContext();
            var courses = dbContext.GetCourses();   //CREATE PROC [dbo].[GetCourses] AS SELECT* FROM Courses
            foreach (var coursesResult in courses)
            {
                Console.WriteLine(coursesResult.Title);
            }
            Console.WriteLine("--------------");
            var course = new Course();
            course.Level = CourseLevel.Beginner;   //1

        }
    }
}
