namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TripleMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menu", "ItemPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menu", "ItemPrice", c => c.Double(nullable: false));
        }
    }
}
