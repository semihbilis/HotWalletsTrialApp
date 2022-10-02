namespace HotWalletsTrialApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HotWalletV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        WalletId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authorizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorizationType = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        WalletId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wallets", t => t.WalletId, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.WalletId);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Icon = c.String(),
                        AccountId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.WalletTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsIncrease = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        WalletId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Wallets", t => t.WalletId, cascadeDelete: true)
                .Index(t => t.WalletId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Icon = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "Id", "dbo.Accounts");
            DropForeignKey("dbo.Authorizations", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Authorizations", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.WalletTransactions", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.WalletTransactions", "CategoryId", "dbo.Categories");
            DropIndex("dbo.WalletTransactions", new[] { "CategoryId" });
            DropIndex("dbo.WalletTransactions", new[] { "WalletId" });
            DropIndex("dbo.Wallets", new[] { "Id" });
            DropIndex("dbo.Authorizations", new[] { "WalletId" });
            DropIndex("dbo.Authorizations", new[] { "AccountId" });
            DropTable("dbo.Categories");
            DropTable("dbo.WalletTransactions");
            DropTable("dbo.Wallets");
            DropTable("dbo.Authorizations");
            DropTable("dbo.Accounts");
        }
    }
}
