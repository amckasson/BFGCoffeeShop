namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "MenuId", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "AdditionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "AdditionId");
            DropColumn("dbo.Customer", "MenuId");
        }
    }
}
