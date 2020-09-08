namespace TradeGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanup : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stock", "MovingAvg1");
            DropColumn("dbo.Stock", "MovingAvg2");
            DropColumn("dbo.Stock", "TotalPrices");
            DropColumn("dbo.Stock", "TotalCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stock", "TotalCount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stock", "TotalPrices", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stock", "MovingAvg2", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Stock", "MovingAvg1", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
