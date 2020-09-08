namespace TradeGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAPeriod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stock", "MAPeriod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stock", "MAPeriod");
        }
    }
}
