namespace TradeGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stock", "MAPeriod1", c => c.Int(nullable: false));
            AddColumn("dbo.Stock", "MAPeriod2", c => c.Int(nullable: false));
            DropColumn("dbo.Stock", "MAPeriod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stock", "MAPeriod", c => c.Int(nullable: false));
            DropColumn("dbo.Stock", "MAPeriod2");
            DropColumn("dbo.Stock", "MAPeriod1");
        }
    }
}
