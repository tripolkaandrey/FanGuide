namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Athletes", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Athletes", "Citizenship", c => c.String(maxLength: 30));
            AlterColumn("dbo.Athletes", "Origin", c => c.String(maxLength: 30));
            AlterColumn("dbo.Sports", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.TeamRoles", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeamRoles", "Name", c => c.String());
            AlterColumn("dbo.Teams", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Sports", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Athletes", "Origin", c => c.String(maxLength: 255));
            AlterColumn("dbo.Athletes", "Citizenship", c => c.String(maxLength: 255));
            AlterColumn("dbo.Athletes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
