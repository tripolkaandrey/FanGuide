namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Age = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Weight = c.Double(),
                        Height = c.Double(),
                        Citizenship = c.String(maxLength: 255),
                        Origin = c.String(maxLength: 255),
                        TeamId = c.Int(),
                        TeamRoleId = c.Int(),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .ForeignKey("dbo.TeamRoles", t => t.TeamRoleId)
                .Index(t => t.TeamId)
                .Index(t => t.TeamRoleId)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        isTeamSport = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Size = c.Int(nullable: false),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.TeamRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.SportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Athletes", "TeamRoleId", "dbo.TeamRoles");
            DropForeignKey("dbo.TeamRoles", "SportId", "dbo.Sports");
            DropForeignKey("dbo.Athletes", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "SportId", "dbo.Sports");
            DropForeignKey("dbo.Athletes", "SportId", "dbo.Sports");
            DropIndex("dbo.TeamRoles", new[] { "SportId" });
            DropIndex("dbo.Teams", new[] { "SportId" });
            DropIndex("dbo.Athletes", new[] { "SportId" });
            DropIndex("dbo.Athletes", new[] { "TeamRoleId" });
            DropIndex("dbo.Athletes", new[] { "TeamId" });
            DropTable("dbo.TeamRoles");
            DropTable("dbo.Teams");
            DropTable("dbo.Sports");
            DropTable("dbo.Athletes");
        }
    }
}
