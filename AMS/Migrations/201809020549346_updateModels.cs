namespace AMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Product_UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProductSizes", "ProductSize_Value", c => c.String());
            AlterColumn("dbo.Notifications", "Notification_ItemType", c => c.String());
            AlterColumn("dbo.Notifications", "Notification_Detail", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "Notification_Detail", c => c.Int(nullable: false));
            AlterColumn("dbo.Notifications", "Notification_ItemType", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductSizes", "ProductSize_Value", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Product_UnitPrice", c => c.Int(nullable: false));
        }
    }
}
