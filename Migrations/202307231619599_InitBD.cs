namespace Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitBD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        C_Id = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        News_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.News_Id, t.Category_Id })
                .ForeignKey("dbo.News", t => t.News_Id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.News_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.NewsCategories", "News_Id", "dbo.News");
            DropIndex("dbo.NewsCategories", new[] { "Category_Id" });
            DropIndex("dbo.NewsCategories", new[] { "News_Id" });
            DropTable("dbo.NewsCategories");
            DropTable("dbo.News");
            DropTable("dbo.Categories");
        }
    }
}
