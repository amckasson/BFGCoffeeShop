namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheActualFinalMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CoffeeOrder", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CoffeeOrder", "FullName", c => c.String());
        }
    }
}
