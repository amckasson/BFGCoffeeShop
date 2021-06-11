namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetOuttaHereGUID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Menu", "MenuTag");
            DropColumn("dbo.CoffeeOrder", "CoffeeOrderTag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CoffeeOrder", "CoffeeOrderTag", c => c.Guid(nullable: false));
            AddColumn("dbo.Menu", "MenuTag", c => c.Guid(nullable: false));
        }
    }
}
