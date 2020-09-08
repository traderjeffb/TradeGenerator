namespace TradeGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingToGit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OurAccount",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OwnerId = c.Guid(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPL = c.Decimal(precision: 18, scale: 2),
                        TradeId = c.Int(),
                        TradePL = c.Decimal(precision: 18, scale: 2),
                        EnterDate = c.DateTime(),
                        ExitDate = c.DateTime(),
                        OpenPL = c.Decimal(precision: 18, scale: 2),
                        TickerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Stock", t => t.TickerId, cascadeDelete: true)
                .Index(t => t.TickerId);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        TickerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Ticker = c.String(),
                        Date = c.DateTime(nullable: false),
                        High = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Low = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Close = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MovingAvg1 = c.Decimal(precision: 18, scale: 2),
                        MovingAvg2 = c.Decimal(precision: 18, scale: 2),
                        TotalPrices = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TickerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.OurAccount", "TickerId", "dbo.Stock");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.OurAccount", new[] { "TickerId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Stock");
            DropTable("dbo.OurAccount");
        }
    }
}