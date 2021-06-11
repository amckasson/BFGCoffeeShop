namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationYes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customer", "MenuId");
            DropColumn("dbo.Customer", "AdditionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "AdditionId", c => c.Int(nullable: false));
            AddColumn("dbo.Customer", "MenuId", c => c.Int(nullable: false));
        }
    }
}
