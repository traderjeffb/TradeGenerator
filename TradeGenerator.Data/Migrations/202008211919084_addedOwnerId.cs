namespace TradeGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOwnerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stock", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stock", "OwnerId");
        }
    }
}
