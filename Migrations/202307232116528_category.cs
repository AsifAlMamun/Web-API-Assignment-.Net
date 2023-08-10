namespace Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsCategories", "News_Id", "dbo.News");
            DropForeignKey("dbo.NewsCategories", "Category_Id", "dbo.Categories");
            DropIndex("dbo.NewsCategories", new[] { "News_Id" });
            DropIndex("dbo.NewsCategories", new[] { "Category_Id" });
            CreateIndex("dbo.News", "C_Id");
            AddForeignKey("dbo.News", "C_Id", "dbo.Categories", "Id", cascadeDelete: true);
            DropTable("dbo.NewsCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        News_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.News_Id, t.Category_Id });
            
            DropForeignKey("dbo.News", "C_Id", "dbo.Categories");
            DropIndex("dbo.News", new[] { "C_Id" });
            CreateIndex("dbo.NewsCategories", "Category_Id");
            CreateIndex("dbo.NewsCategories", "News_Id");
            AddForeignKey("dbo.NewsCategories", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NewsCategories", "News_Id", "dbo.News", "Id", cascadeDelete: true);
        }
    }
}
