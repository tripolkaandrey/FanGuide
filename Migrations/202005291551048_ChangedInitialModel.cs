namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedInitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Byte(nullable: false),
                        Athlete_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Athletes", t => t.Athlete_Id)
                .Index(t => t.Athlete_Id);
            
            CreateTable(
                "dbo.Sexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Athletes", "SexId", c => c.Int());
            CreateIndex("dbo.Athletes", "SexId");
            AddForeignKey("dbo.Athletes", "SexId", "dbo.Sexes", "Id");
            DropColumn("dbo.Athletes", "Sex");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Athletes", "Sex", c => c.Int(nullable: false));
            DropForeignKey("dbo.Athletes", "SexId", "dbo.Sexes");
            DropForeignKey("dbo.Achievements", "Athlete_Id", "dbo.Athletes");
            DropIndex("dbo.Achievements", new[] { "Athlete_Id" });
            DropIndex("dbo.Athletes", new[] { "SexId" });
            DropColumn("dbo.Athletes", "SexId");
            DropTable("dbo.Sexes");
            DropTable("dbo.Achievements");
        }
    }
}
