using System.Collections.Generic;

namespace CodeFirst
{
    public class Author {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }   //assume an author could have many courses but one course could only created by one author.
    }
}