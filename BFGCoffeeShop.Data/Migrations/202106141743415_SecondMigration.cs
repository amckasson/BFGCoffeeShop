namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menu", "CustomerId", "dbo.Customer");
            DropIndex("dbo.Menu", new[] { "CustomerId" });
            DropColumn("dbo.Addition", "CustomerId");
            DropColumn("dbo.Menu", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menu", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Addition", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menu", "CustomerId");
            AddForeignKey("dbo.Menu", "CustomerId", "dbo.Customer", "CustomerId", cascadeDelete: true);
        }
    }
}
