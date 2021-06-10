namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class andrewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addition", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Addition", "AdditionTag", c => c.Guid(nullable: false));
            AddColumn("dbo.Menu", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Menu", "MenuTag", c => c.Guid(nullable: false));
            CreateIndex("dbo.Addition", "CustomerId");
            CreateIndex("dbo.Menu", "CustomerId");
            AddForeignKey("dbo.Addition", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Menu", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menu", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Addition", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Menu", new[] { "CustomerId" });
            DropIndex("dbo.Addition", new[] { "CustomerId" });
            DropColumn("dbo.Menu", "MenuTag");
            DropColumn("dbo.Menu", "CustomerId");
            DropColumn("dbo.Addition", "AdditionTag");
            DropColumn("dbo.Addition", "CustomerId");
        }
    }
}
