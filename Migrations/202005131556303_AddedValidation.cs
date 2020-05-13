namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Athletes", "Achievements", c => c.String(maxLength: 255));
            AlterColumn("dbo.Athletes", "Citizenship", c => c.String(maxLength: 255));
            AlterColumn("dbo.Athletes", "Origin", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Athletes", "Origin", c => c.String());
            AlterColumn("dbo.Athletes", "Citizenship", c => c.String());
            AlterColumn("dbo.Athletes", "Achievements", c => c.String());
        }
    }
}
