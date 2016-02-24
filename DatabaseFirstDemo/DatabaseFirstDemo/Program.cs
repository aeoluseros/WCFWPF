using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo {
    class Program {
        static void Main(string[] args) {
            //create an instance of DbContext class
            using (var context = new NETTestEntities()) {
                using (var transaction = context.Database.BeginTransaction()) {
                    var post = new Post() {
                        PostID = 1, //PostID is an identity column, we don't have to specify it
                        DatePublished = DateTime.Now,
                        Title = "Title",
                        Body = "Body"
                    };
                    context.Posts.Add(post); //add to DbSet<Posts>
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Posts ON");
                    context.SaveChanges(); //commit to database;
                    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Posts OFF");

                    transaction.Commit();
                }
            }
        }
    }
}
