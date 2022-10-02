namespace HotWalletsTrialApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameChangedUsername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Accounts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Accounts", "Username");
        }
    }
}
