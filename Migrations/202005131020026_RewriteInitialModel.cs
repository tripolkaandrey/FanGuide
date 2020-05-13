namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RewriteInitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.SportId);
            
            AddColumn("dbo.Athletes", "Achievements", c => c.String());
            AddColumn("dbo.Athletes", "TeamId", c => c.Int());
            AlterColumn("dbo.Sports", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Athletes", "TeamId");
            AddForeignKey("dbo.Athletes", "TeamId", "dbo.Teams", "Id");
            DropColumn("dbo.Athletes", "Team");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Athletes", "Team", c => c.String());
            DropForeignKey("dbo.Athletes", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "SportId", "dbo.Sports");
            DropIndex("dbo.Teams", new[] { "SportId" });
            DropIndex("dbo.Athletes", new[] { "TeamId" });
            AlterColumn("dbo.Sports", "Name", c => c.String());
            DropColumn("dbo.Athletes", "TeamId");
            DropColumn("dbo.Athletes", "Achievements");
            DropTable("dbo.Teams");
        }
    }
}
