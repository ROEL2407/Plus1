namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.NewsArticles",
                c => new
                    {
                        ArticleID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArticleID)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentID = c.Int(nullable: false),
                        Parent_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Categories", t => t.Parent_CategoryID)
                .Index(t => t.Parent_CategoryID);
            
            CreateTable(
                "dbo.SubSubCategories",
                c => new
                    {
                        SubSubCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentID = c.Int(nullable: false),
                        Parent_SubCategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.SubSubCategoryID)
                .ForeignKey("dbo.SubCategories", t => t.Parent_SubCategoryID)
                .Index(t => t.Parent_SubCategoryID);
            
            AddColumn("dbo.Products", "Image", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubSubCategories", "Parent_SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "Parent_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.NewsArticles", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.SubSubCategories", new[] { "Parent_SubCategoryID" });
            DropIndex("dbo.SubCategories", new[] { "Parent_CategoryID" });
            DropIndex("dbo.NewsArticles", new[] { "AuthorId" });
            DropColumn("dbo.AspNetUsers", "UserRole");
            DropColumn("dbo.Products", "Image");
            DropTable("dbo.SubSubCategories");
            DropTable("dbo.SubCategories");
            DropTable("dbo.NewsArticles");
            DropTable("dbo.Categories");
        }
    }
}
