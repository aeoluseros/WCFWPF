using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo {
    public class PostCodeFirst {
        [Key]
        public int PostID { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class BlogDbContext : DbContext       //
    {
        public DbSet<PostCodeFirst> PostCodeFirst { get; set; }
    }

    class Program {
        static void Main(string[] args) {



        }
    }
}
