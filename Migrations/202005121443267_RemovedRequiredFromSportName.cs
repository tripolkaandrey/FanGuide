namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequiredFromSportName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sports", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sports", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
