namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Courses", "Name", c => c.String()); //it will convert to varchar(max) by default
            //override the convention and make it not nullable
            //AddColumn("dbo.Courses", "Name", c => c.String(nullable:false)); 
            //DropColumn("dbo.Courses", "Title"); //it's dangerous to use the default DropColumn
            //so we can use RenameColumn method:
            RenameColumn("dbo.Courses", "Title", "Name");

            //or we can use SQL method:
            //AddColumn("dbo.Courses", "Name", c => c.String(nullable:false)); 
            //Sql("UPDATE Courses SET Name = Title");
            //DropColumn("dbo.Courses", "Title"); 

        }

        public override void Down()
        {
            //be careful now, we need to modify Down() method also.
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false));

            //add in the Sql method:
            Sql("UPDATE Courses SET Name = Title");

            DropColumn("dbo.Courses", "Name");
        }
    }
}
