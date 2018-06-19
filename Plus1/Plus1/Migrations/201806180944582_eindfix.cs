namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eindfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewsArticles", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.NewsArticles", new[] { "AuthorId" });
            DropPrimaryKey("dbo.NewsArticles");
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        Expirationdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CartID);
            
            AddColumn("dbo.NewsArticles", "NewsArticleID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.AspNetUsers", "Firstname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zipcode", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.Products", "Category", c => c.String());
            AddColumn("dbo.Products", "Subcategory", c => c.String());
            AddColumn("dbo.Products", "SubSubcategory", c => c.String());
            AddPrimaryKey("dbo.NewsArticles", "NewsArticleID");
            DropColumn("dbo.NewsArticles", "ArticleID");
            DropColumn("dbo.NewsArticles", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NewsArticles", "AuthorId", c => c.String(maxLength: 128));
            AddColumn("dbo.NewsArticles", "ArticleID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.NewsArticles");
            DropColumn("dbo.Products", "SubSubcategory");
            DropColumn("dbo.Products", "Subcategory");
            DropColumn("dbo.Products", "Category");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Zipcode");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Firstname");
            DropColumn("dbo.NewsArticles", "NewsArticleID");
            DropTable("dbo.Carts");
            AddPrimaryKey("dbo.NewsArticles", "ArticleID");
            CreateIndex("dbo.NewsArticles", "AuthorId");
            AddForeignKey("dbo.NewsArticles", "AuthorId", "dbo.AspNetUsers", "Id");
        }
    }
}
