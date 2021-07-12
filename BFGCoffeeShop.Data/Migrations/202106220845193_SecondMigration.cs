namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customer", new[] { "CustomerId" });
            RenameColumn(table: "dbo.CoffeeOrder", name: "CustomerId", newName: "Customer_CustomerId");
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Customer", "CustomerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customer", "CustomerId");
            CreateIndex("dbo.CoffeeOrder", "Customer_CustomerId");
            AddForeignKey("dbo.CoffeeOrder", "Customer_CustomerId", "dbo.Customer", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoffeeOrder", "Customer_CustomerId", "dbo.Customer");
            DropIndex("dbo.CoffeeOrder", new[] { "Customer_CustomerId" });
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Customer", "CustomerId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customer", "CustomerId");
            RenameColumn(table: "dbo.CoffeeOrder", name: "Customer_CustomerId", newName: "CustomerId");
            CreateIndex("dbo.Customer", "CustomerId");
        }
    }
}
