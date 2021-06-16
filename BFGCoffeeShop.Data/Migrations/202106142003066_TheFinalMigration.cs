namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheFinalMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addition", "TotalPrice");
            DropColumn("dbo.Menu", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menu", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Addition", "TotalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
