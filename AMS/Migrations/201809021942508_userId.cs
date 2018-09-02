namespace AMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Vendors", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.Vendors", "Id");
            RenameColumn(table: "dbo.Customers", name: "ApplicationUser_Id", newName: "Id");
            RenameColumn(table: "dbo.Vendors", name: "ApplicationUser_Id", newName: "Id");
            AlterColumn("dbo.Customers", "Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Vendors", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "Id");
            CreateIndex("dbo.Vendors", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vendors", new[] { "Id" });
            DropIndex("dbo.Customers", new[] { "Id" });
            AlterColumn("dbo.Vendors", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Vendors", name: "Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Customers", name: "Id", newName: "ApplicationUser_Id");
            AddColumn("dbo.Vendors", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Vendors", "ApplicationUser_Id");
            CreateIndex("dbo.Customers", "ApplicationUser_Id");
        }
    }
}
