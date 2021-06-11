namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoffeeOrder", "CoffeeOrderTag", c => c.Guid(nullable: false));
            AddColumn("dbo.CoffeeOrder", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.CoffeeOrder", "CustomerId");
            AddForeignKey("dbo.CoffeeOrder", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoffeeOrder", "CustomerId", "dbo.Customer");
            DropIndex("dbo.CoffeeOrder", new[] { "CustomerId" });
            DropColumn("dbo.CoffeeOrder", "CustomerId");
            DropColumn("dbo.CoffeeOrder", "CoffeeOrderTag");
        }
    }
}
