namespace TradeGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedNam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        TickerId = c.Int(nullable: false, identity: true),
                        Ticker = c.String(),
                        Date = c.DateTime(nullable: false),
                        High = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Low = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Close = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TickerId);
            
            DropTable("dbo.Trade");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Trade",
                c => new
                    {
                        TickerId = c.Int(nullable: false, identity: true),
                        EnterDate = c.DateTime(nullable: false),
                        ExitDate = c.DateTime(nullable: false),
                        ProfitLoss = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TickerId);
            
            DropTable("dbo.Stock");
        }
    }
}
