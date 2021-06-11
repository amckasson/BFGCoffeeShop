namespace BFGCoffeeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimpleSimpleSimp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addition", "AdditionTag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addition", "AdditionTag", c => c.Guid(nullable: false));
        }
    }
}
