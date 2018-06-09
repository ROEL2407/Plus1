namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationFix : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsArticles", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.NewsArticles", new[] { "AuthorId" });
            DropTable("dbo.NewsArticles");
        }
    }
}
