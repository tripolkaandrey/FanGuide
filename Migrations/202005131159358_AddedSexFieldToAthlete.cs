namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSexFieldToAthlete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athletes", "Sex", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Athletes", "Sex");
        }
    }
}
