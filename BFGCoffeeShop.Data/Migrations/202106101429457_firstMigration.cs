namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addition", "CoffeeOrder_CoffeeOrderId", c => c.Int());
            AlterColumn("dbo.Addition", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.CoffeeOrder", "AdditionId", c => c.Int());
            AlterColumn("dbo.Menu", "ItemPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Addition", "CoffeeOrder_CoffeeOrderId");
            CreateIndex("dbo.CoffeeOrder", "CustomerId");
            CreateIndex("dbo.CoffeeOrder", "MenuId");
            AddForeignKey("dbo.Addition", "CoffeeOrder_CoffeeOrderId", "dbo.CoffeeOrder", "CoffeeOrderId");
            AddForeignKey("dbo.CoffeeOrder", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.CoffeeOrder", "MenuId", "dbo.Menu", "MenuId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoffeeOrder", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.CoffeeOrder", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Addition", "CoffeeOrder_CoffeeOrderId", "dbo.CoffeeOrder");
            DropIndex("dbo.CoffeeOrder", new[] { "MenuId" });
            DropIndex("dbo.CoffeeOrder", new[] { "CustomerId" });
            DropIndex("dbo.Addition", new[] { "CoffeeOrder_CoffeeOrderId" });
            AlterColumn("dbo.Menu", "ItemPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.CoffeeOrder", "AdditionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Addition", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Addition", "CoffeeOrder_CoffeeOrderId");
        }
    }
}
