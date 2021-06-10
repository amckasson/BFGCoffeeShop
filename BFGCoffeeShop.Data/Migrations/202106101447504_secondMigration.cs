namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "CoffeeOrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "CoffeeOrderId", c => c.Int(nullable: false));
        }
    }
}
