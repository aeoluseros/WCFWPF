using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst {
    class Program {
        static void Main(string[] args)
        {
            var dbContext = new PlutoDbContext();
            var courses = dbContext.GetCourses();   //CREATE PROC [dbo].[GetCourses] AS SELECT* FROM Courses
            foreach (var coursesResult in courses)
            {
                Console.WriteLine(coursesResult.Title);
            }
        }
    }
}
