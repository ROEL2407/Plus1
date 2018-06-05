namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Weight", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
