namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuadMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addition", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addition", "Price", c => c.Double(nullable: false));
        }
    }
}
