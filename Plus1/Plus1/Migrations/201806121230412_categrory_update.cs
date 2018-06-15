namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categrory_update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SubCategories", "ParentID");
            DropColumn("dbo.SubSubCategories", "ParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubSubCategories", "ParentID", c => c.Int(nullable: false));
            AddColumn("dbo.SubCategories", "ParentID", c => c.Int(nullable: false));
        }
    }
}
