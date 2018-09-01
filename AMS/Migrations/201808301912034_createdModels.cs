namespace AMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                        Category_Title = c.String(nullable: false),
                        Category_Code = c.String(nullable: false),
                        Category_Description = c.String(),
                        Category_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.CategorySubs",
                c => new
                    {
                        CategorySub_Id = c.Int(nullable: false, identity: true),
                        Category_Id = c.Int(nullable: false),
                        CategorySub_Title = c.String(nullable: false),
                        CategorySub_Code = c.String(nullable: false),
                        CategorySub_Description = c.String(),
                        CategorySub_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategorySub_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Customer_Name = c.String(),
                        Customer_MobileNo = c.String(),
                        Customer_Address = c.String(),
                        Customer_Remaining = c.Int(nullable: false),
                        Customer_Status = c.Boolean(nullable: false),
                        Customer_NTN = c.String(),
                        Customer_Company = c.String(),
                        Customer_Date = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Customer_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.GatePass_Ch",
                c => new
                    {
                        GPC_Id = c.Int(nullable: false, identity: true),
                        GPP_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        GPC_Quantity = c.Int(nullable: false),
                        GPC_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GPC_Description = c.String(),
                        GPC_GST = c.Int(nullable: false),
                        GPC_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GPC_Unit = c.String(),
                    })
                .PrimaryKey(t => t.GPC_Id)
                .ForeignKey("dbo.GatePass_Pt", t => t.GPP_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.GPP_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.GatePass_Pt",
                c => new
                    {
                        GPP_Id = c.Int(nullable: false, identity: true),
                        Vendor_Id = c.Int(nullable: false),
                        GPP_TotalQuantity = c.Int(nullable: false),
                        GPP_TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GPP_TotalPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GPP_Date = c.DateTime(nullable: false),
                        GPP_ModificationDate = c.DateTime(nullable: false),
                        GPP_Charges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GPP_TaxPercent = c.Int(nullable: false),
                        GPP_TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GPP_No = c.String(),
                        GPP_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GPP_Id)
                .ForeignKey("dbo.Vendors", t => t.Vendor_Id, cascadeDelete: true)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Vendor_Id = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Vendor_Name = c.String(),
                        Vendor_MobileNo = c.String(),
                        Vendor_Address = c.String(),
                        Vendor_Remaining = c.Int(nullable: false),
                        Vendor_Status = c.Boolean(nullable: false),
                        Vendor_NTN = c.String(),
                        Vendor_Company = c.String(),
                        Vendor_Date = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Vendor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_Id = c.Int(nullable: false, identity: true),
                        CategorySub_Id = c.Int(nullable: false),
                        ProductSize_Id = c.Int(nullable: false),
                        Product_Title = c.String(nullable: false),
                        Product_Code = c.String(nullable: false),
                        Product_Description = c.String(),
                        Product_Weight = c.Int(nullable: false),
                        Product_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Status = c.Boolean(nullable: false),
                        Product_Color = c.String(),
                        Product_Date = c.DateTime(nullable: false),
                        Product_Unit = c.String(),
                        Product_UnitPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Product_Id)
                .ForeignKey("dbo.CategorySubs", t => t.CategorySub_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductSizes", t => t.ProductSize_Id, cascadeDelete: true)
                .Index(t => t.CategorySub_Id)
                .Index(t => t.ProductSize_Id);
            
            CreateTable(
                "dbo.ProductSizes",
                c => new
                    {
                        ProductSize_Id = c.Int(nullable: false, identity: true),
                        ProductSize_Value = c.Int(nullable: false),
                        ProductSize_Height = c.Int(nullable: false),
                        ProductSize_Width = c.Int(nullable: false),
                        ProductSize_Length = c.Int(nullable: false),
                        ProductSize_Unit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductSize_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Invoice_Id = c.Int(nullable: false, identity: true),
                        Invoice_No = c.Int(nullable: false),
                        Invoice_Type = c.String(),
                        SalePurchase_Id = c.Int(nullable: false),
                        Invoice_Status = c.Boolean(nullable: false),
                        Invoice_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Notification_Id = c.Int(nullable: false, identity: true),
                        Notification_ItemId = c.Int(nullable: false),
                        Notification_ItemType = c.Int(nullable: false),
                        Notification_Detail = c.Int(nullable: false),
                        Notification_Date = c.DateTime(nullable: false),
                        Notification_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Notification_Id);
            
            CreateTable(
                "dbo.OpeningClosings",
                c => new
                    {
                        OpeningClosing_Id = c.Int(nullable: false, identity: true),
                        OpeningClosing_OpeningBalance = c.Int(nullable: false),
                        OpeningClosing_ClosingBalance = c.Int(nullable: false),
                        OpeningClosing_IsClosed = c.Boolean(nullable: false),
                        OpeningClosing_Date = c.DateTime(nullable: false),
                        OpeningClosing_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OpeningClosing_Id);
            
            CreateTable(
                "dbo.PurchaseOrder_Ch",
                c => new
                    {
                        POC_Id = c.Int(nullable: false, identity: true),
                        POP_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        POC_Quantity = c.Int(nullable: false),
                        POC_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        POC_Description = c.String(),
                        POC_GST = c.Int(nullable: false),
                        POC_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        POC_ItemCode = c.String(),
                        POC_Unit = c.String(),
                        PurchaseOrder_Pt_PO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.POC_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrder_Pt", t => t.PurchaseOrder_Pt_PO_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.PurchaseOrder_Pt_PO_Id);
            
            CreateTable(
                "dbo.PurchaseOrder_Pt",
                c => new
                    {
                        PO_Id = c.Int(nullable: false, identity: true),
                        POP_TotalQuantity = c.Int(nullable: false),
                        POP_TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        POP_TotalPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        POP_Date = c.DateTime(nullable: false),
                        POP_ModificationDate = c.DateTime(nullable: false),
                        POP_Charges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        POP_TaxPercent = c.Int(nullable: false),
                        POP_TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        POP_PO = c.String(),
                        Vendor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PO_Id)
                .ForeignKey("dbo.Vendors", t => t.Vendor_Id, cascadeDelete: true)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SaleOrder_Ch",
                c => new
                    {
                        SOC_Id = c.Int(nullable: false, identity: true),
                        SOP_Id = c.Int(nullable: false),
                        SOC_Quantity = c.Int(nullable: false),
                        SOC_Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOC_Description = c.String(),
                        SOC_GST = c.Int(nullable: false),
                        SOC_Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOC_ItemCode = c.Int(nullable: false),
                        SOC_Unit = c.String(),
                    })
                .PrimaryKey(t => t.SOC_Id)
                .ForeignKey("dbo.SaleOrder_Pt", t => t.SOP_Id, cascadeDelete: true)
                .Index(t => t.SOP_Id);
            
            CreateTable(
                "dbo.SaleOrder_Pt",
                c => new
                    {
                        SOP_Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        SOP_TotalQuantity = c.Int(nullable: false),
                        SOP_TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOP_TotalReceived = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOP_Date = c.DateTime(nullable: false),
                        SOP_ModificationDate = c.DateTime(nullable: false),
                        SOP_Charges = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOP_TaxPercent = c.Int(nullable: false),
                        SOP_TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SOP_SO = c.String(),
                        Customer_Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.SOP_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Customer_Id)
                .Index(t => t.Customer_Customer_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Transaction_Id = c.Int(nullable: false, identity: true),
                        OpeningClosing_Id = c.Int(nullable: false),
                        Transaction_ItemId = c.Int(nullable: false),
                        Transaction_ItemType = c.String(),
                        Transaction_Description = c.String(),
                        Transaction_Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Transaction_Credit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Transaction_IsCash = c.Boolean(nullable: false),
                        Transaction_BankAccountNo = c.String(),
                        Transaction_CheckBookNo = c.Int(nullable: false),
                        Transaction_Date = c.DateTime(nullable: false),
                        Transaction_Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Transaction_Id)
                .ForeignKey("dbo.OpeningClosings", t => t.OpeningClosing_Id, cascadeDelete: true)
                .Index(t => t.OpeningClosing_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "OpeningClosing_Id", "dbo.OpeningClosings");
            DropForeignKey("dbo.SaleOrder_Ch", "SOP_Id", "dbo.SaleOrder_Pt");
            DropForeignKey("dbo.SaleOrder_Pt", "Customer_Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PurchaseOrder_Ch", "PurchaseOrder_Pt_PO_Id", "dbo.PurchaseOrder_Pt");
            DropForeignKey("dbo.PurchaseOrder_Pt", "Vendor_Id", "dbo.Vendors");
            DropForeignKey("dbo.PurchaseOrder_Ch", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.GatePass_Ch", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductSize_Id", "dbo.ProductSizes");
            DropForeignKey("dbo.Products", "CategorySub_Id", "dbo.CategorySubs");
            DropForeignKey("dbo.GatePass_Ch", "GPP_Id", "dbo.GatePass_Pt");
            DropForeignKey("dbo.GatePass_Pt", "Vendor_Id", "dbo.Vendors");
            DropForeignKey("dbo.Vendors", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CategorySubs", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "OpeningClosing_Id" });
            DropIndex("dbo.SaleOrder_Pt", new[] { "Customer_Customer_Id" });
            DropIndex("dbo.SaleOrder_Ch", new[] { "SOP_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PurchaseOrder_Pt", new[] { "Vendor_Id" });
            DropIndex("dbo.PurchaseOrder_Ch", new[] { "PurchaseOrder_Pt_PO_Id" });
            DropIndex("dbo.PurchaseOrder_Ch", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "ProductSize_Id" });
            DropIndex("dbo.Products", new[] { "CategorySub_Id" });
            DropIndex("dbo.Vendors", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.GatePass_Pt", new[] { "Vendor_Id" });
            DropIndex("dbo.GatePass_Ch", new[] { "Product_Id" });
            DropIndex("dbo.GatePass_Ch", new[] { "GPP_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Customers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CategorySubs", new[] { "Category_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.SaleOrder_Pt");
            DropTable("dbo.SaleOrder_Ch");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PurchaseOrder_Pt");
            DropTable("dbo.PurchaseOrder_Ch");
            DropTable("dbo.OpeningClosings");
            DropTable("dbo.Notifications");
            DropTable("dbo.Invoices");
            DropTable("dbo.ProductSizes");
            DropTable("dbo.Products");
            DropTable("dbo.Vendors");
            DropTable("dbo.GatePass_Pt");
            DropTable("dbo.GatePass_Ch");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Customers");
            DropTable("dbo.CategorySubs");
            DropTable("dbo.Categories");
        }
    }
}
