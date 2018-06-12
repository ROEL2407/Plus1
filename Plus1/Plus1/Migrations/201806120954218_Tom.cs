namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsArticles",
                c => new
                    {
                        NewsArticleID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NewsArticleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsArticles");
        }
    }
}
