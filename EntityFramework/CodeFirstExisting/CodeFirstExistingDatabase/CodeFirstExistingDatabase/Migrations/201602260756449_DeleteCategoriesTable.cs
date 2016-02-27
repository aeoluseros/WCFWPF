namespace CodeFirstExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DeleteCategoriesTable : DbMigration {
        public override void Up() {
            CreateTable(
               "dbo.Categories_Hist",
               c => new {
                   ID = c.Int(nullable: false, identity: true),
                   Name = c.String(),
               })
               .PrimaryKey(t => t.ID);

            Sql("INSERT INTO Categories_Hist (Name) SELECT Name FROM Categories;");

            DropTable("dbo.Categories");
        }

        //because we changed our Up() method, we should always look into our Down() method.
        public override void Down() {
            CreateTable(
                "dbo.Categories",
                c => new {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.ID);

            Sql("INSERT INTO Categories (Name) SELECT Name FROM Categories_Hist;");

            DropTable("dbo.Categories_Hist");
        }
    }
}
