namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryColumnToCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Category_ID", c => c.Int());
            CreateIndex("dbo.Courses", "Category_ID");
            AddForeignKey("dbo.Courses", "Category_ID", "dbo.Categories", "ID");

            Sql("UPDATE Courses SET Category_ID = 1");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_ID" });
            DropColumn("dbo.Courses", "Category_ID");
        }
    }
}
