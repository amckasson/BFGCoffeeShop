namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoffeeOrder",
                c => new
                    {
                        CoffeeOrderId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Edited = c.DateTimeOffset(precision: 7),
                        Country = c.String(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Barista = c.String(),
                    })
                .PrimaryKey(t => t.CoffeeOrderId);
            
            CreateTable(
                "dbo.CoffeeShop",
                c => new
                    {
                        CoffeeShopId = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        CoffeeOrderId = c.Int(nullable: false),
                        ShopName = c.String(),
                        Location = c.String(),
                        PhoneNumber = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.CoffeeShopId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerTag = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PaymentType = c.String(nullable: false),
                        CoffeeOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        ItemPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menu");
            DropTable("dbo.Customer");
            DropTable("dbo.CoffeeShop");
            DropTable("dbo.CoffeeOrder");
        }
    }
}
