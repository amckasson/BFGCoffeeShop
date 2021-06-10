namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoffeeOrder", "CoffeeOrderTag", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CoffeeOrder", "CoffeeOrderTag");
        }
    }
}
