namespace ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Customer");
            RenameTable(name: "dbo.Orders", newName: "Order");
            RenameTable(name: "dbo.Products", newName: "Product");
            DropForeignKey("dbo.Customers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Customer", new[] { "User_Id" });
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Product_Id = c.Guid(nullable: false),
                        Order_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Order_Id);
            
            AddColumn("dbo.Customer", "User_UserName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Customer", "User_Password", c => c.String(nullable: false, maxLength: 32, fixedLength: true));
            AddColumn("dbo.Customer", "User_ConfirmPassword", c => c.String());
            AddColumn("dbo.Customer", "User_Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customer", "Name_FirstName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Customer", "Name_LastName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Customer", "Email_Address", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.Customer", "Document_Number", c => c.String(nullable: false, maxLength: 11, fixedLength: true));
            AlterColumn("dbo.Customer", "User_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Order", "Number", c => c.String(nullable: false, maxLength: 8, fixedLength: true));
            AlterColumn("dbo.Order", "DeliveryFee", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Order", "Discount", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Order", "Customer_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Product", "Title", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Product", "Image", c => c.String(nullable: false, maxLength: 1024));
            CreateIndex("dbo.Order", "Customer_Id");
            AddForeignKey("dbo.Order", "Customer_Id", "dbo.Customer", "Id", cascadeDelete: true);
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Order", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.OrderItem", "Order_Id", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "Product_Id", "dbo.Product");
            DropIndex("dbo.OrderItem", new[] { "Order_Id" });
            DropIndex("dbo.OrderItem", new[] { "Product_Id" });
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            AlterColumn("dbo.Product", "Image", c => c.String());
            AlterColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Product", "Title", c => c.String());
            AlterColumn("dbo.Order", "Customer_Id", c => c.Guid());
            AlterColumn("dbo.Order", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Order", "DeliveryFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Order", "Number", c => c.String());
            AlterColumn("dbo.Customer", "User_Id", c => c.Guid());
            AlterColumn("dbo.Customer", "Document_Number", c => c.String());
            AlterColumn("dbo.Customer", "Email_Address", c => c.String());
            AlterColumn("dbo.Customer", "Name_LastName", c => c.String());
            AlterColumn("dbo.Customer", "Name_FirstName", c => c.String());
            DropColumn("dbo.Customer", "User_Active");
            DropColumn("dbo.Customer", "User_ConfirmPassword");
            DropColumn("dbo.Customer", "User_Password");
            DropColumn("dbo.Customer", "User_UserName");
            DropTable("dbo.OrderItem");
            CreateIndex("dbo.Order", "Customer_Id");
            CreateIndex("dbo.Customer", "User_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.Users", "Id");
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Order", newName: "Orders");
            RenameTable(name: "dbo.Customer", newName: "Customers");
        }
    }
}
