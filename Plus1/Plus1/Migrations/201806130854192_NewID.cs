namespace Plus1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategories", "Parent_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.SubSubCategories", "Parent_SubCategoryID", "dbo.SubCategories");
            DropIndex("dbo.SubCategories", new[] { "Parent_CategoryID" });
            DropIndex("dbo.SubSubCategories", new[] { "Parent_SubCategoryID" });
            RenameColumn(table: "dbo.SubCategories", name: "Parent_CategoryID", newName: "Parent_Name");
            RenameColumn(table: "dbo.SubSubCategories", name: "Parent_SubCategoryID", newName: "Parent_Name");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.SubCategories");
            DropPrimaryKey("dbo.SubSubCategories");
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SubCategories", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SubCategories", "Parent_Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.SubSubCategories", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.SubSubCategories", "Parent_Name", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Categories", "Name");
            AddPrimaryKey("dbo.SubCategories", "Name");
            AddPrimaryKey("dbo.SubSubCategories", "Name");
            CreateIndex("dbo.SubCategories", "Parent_Name");
            CreateIndex("dbo.SubSubCategories", "Parent_Name");
            AddForeignKey("dbo.SubCategories", "Parent_Name", "dbo.Categories", "Name");
            AddForeignKey("dbo.SubSubCategories", "Parent_Name", "dbo.SubCategories", "Name");
            DropColumn("dbo.Categories", "CategoryID");
            DropColumn("dbo.SubCategories", "SubCategoryID");
            DropColumn("dbo.SubSubCategories", "SubSubCategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubSubCategories", "SubSubCategoryID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.SubCategories", "SubCategoryID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Categories", "CategoryID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.SubSubCategories", "Parent_Name", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "Parent_Name", "dbo.Categories");
            DropIndex("dbo.SubSubCategories", new[] { "Parent_Name" });
            DropIndex("dbo.SubCategories", new[] { "Parent_Name" });
            DropPrimaryKey("dbo.SubSubCategories");
            DropPrimaryKey("dbo.SubCategories");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.SubSubCategories", "Parent_Name", c => c.Int());
            AlterColumn("dbo.SubSubCategories", "Name", c => c.String());
            AlterColumn("dbo.SubCategories", "Parent_Name", c => c.Int());
            AlterColumn("dbo.SubCategories", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AddPrimaryKey("dbo.SubSubCategories", "SubSubCategoryID");
            AddPrimaryKey("dbo.SubCategories", "SubCategoryID");
            AddPrimaryKey("dbo.Categories", "CategoryID");
            RenameColumn(table: "dbo.SubSubCategories", name: "Parent_Name", newName: "Parent_SubCategoryID");
            RenameColumn(table: "dbo.SubCategories", name: "Parent_Name", newName: "Parent_CategoryID");
            CreateIndex("dbo.SubSubCategories", "Parent_SubCategoryID");
            CreateIndex("dbo.SubCategories", "Parent_CategoryID");
            AddForeignKey("dbo.SubSubCategories", "Parent_SubCategoryID", "dbo.SubCategories", "SubCategoryID");
            AddForeignKey("dbo.SubCategories", "Parent_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
