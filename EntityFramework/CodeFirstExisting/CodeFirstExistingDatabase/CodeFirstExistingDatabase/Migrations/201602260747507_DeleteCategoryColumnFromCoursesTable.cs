namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoryColumnFromCoursesTable : DbMigration
    {
        public override void Up()
        {
            //when you delete navigation propery like Category, you always see these three together
            DropForeignKey("dbo.Courses", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_ID" });
            DropColumn("dbo.Courses", "Category_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Category_ID", c => c.Int());
            CreateIndex("dbo.Courses", "Category_ID");
            AddForeignKey("dbo.Courses", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
