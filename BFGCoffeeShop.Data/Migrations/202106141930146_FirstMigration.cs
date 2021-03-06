namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addition",
                c => new
                    {
                        AdditionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoffeeOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdditionId)
                .ForeignKey("dbo.CoffeeOrder", t => t.CoffeeOrderId, cascadeDelete: true)
                .Index(t => t.CoffeeOrderId);
            
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
                        CoffeeShopId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoffeeOrderId)
                .ForeignKey("dbo.CoffeeShop", t => t.CoffeeShopId, cascadeDelete: true)
                .Index(t => t.CoffeeShopId);
            
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
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.CoffeeOrder", t => t.CoffeeOrderId, cascadeDelete: true)
                .Index(t => t.CoffeeOrderId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CoffeeOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.CoffeeOrder", t => t.CoffeeOrderId, cascadeDelete: true)
                .Index(t => t.CoffeeOrderId);
            
            CreateTable(
                "dbo.CoffeeShop",
                c => new
                    {
                        CoffeeShopId = c.Int(nullable: false, identity: true),
                        ShopName = c.String(),
                        Location = c.String(),
                        PhoneNumber = c.String(),
                        Website = c.String(),
                        CoffeeOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CoffeeShopId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.CoffeeOrder", "CoffeeShopId", "dbo.CoffeeShop");
            DropForeignKey("dbo.Menu", "CoffeeOrderId", "dbo.CoffeeOrder");
            DropForeignKey("dbo.Customer", "CoffeeOrderId", "dbo.CoffeeOrder");
            DropForeignKey("dbo.Addition", "CoffeeOrderId", "dbo.CoffeeOrder");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Menu", new[] { "CoffeeOrderId" });
            DropIndex("dbo.Customer", new[] { "CoffeeOrderId" });
            DropIndex("dbo.CoffeeOrder", new[] { "CoffeeShopId" });
            DropIndex("dbo.Addition", new[] { "CoffeeOrderId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.CoffeeShop");
            DropTable("dbo.Menu");
            DropTable("dbo.Customer");
            DropTable("dbo.CoffeeOrder");
            DropTable("dbo.Addition");
        }
    }
}
