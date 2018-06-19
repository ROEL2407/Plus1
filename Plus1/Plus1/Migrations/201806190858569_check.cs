namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Category", c => c.String());
            AddColumn("dbo.Products", "Subcategory", c => c.String());
            AddColumn("dbo.Products", "SubSubcategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SubSubcategory");
            DropColumn("dbo.Products", "Subcategory");
            DropColumn("dbo.Products", "Category");
        }
    }
}
