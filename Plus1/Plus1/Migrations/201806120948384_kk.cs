namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kk : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            
            
            DropTable("dbo.Carts");
            CreateIndex("dbo.NewsArticles", "AuthorId");
            AddForeignKey("dbo.NewsArticles", "AuthorId", "dbo.AspNetUsers", "Id");
        }
    }
}
