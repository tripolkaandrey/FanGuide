namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateSports : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sports (Name) VALUES('Basketball')");
            Sql("INSERT INTO Sports (Name) VALUES('Volleyball')");
            Sql("INSERT INTO Sports (Name) VALUES('Football')");
            Sql("INSERT INTO Sports (Name) VALUES('Hockey')");
            Sql("INSERT INTO Sports (Name) VALUES('Sambo')");
            Sql("INSERT INTO Sports (Name) VALUES('Karate')");
            Sql("INSERT INTO Sports (Name) VALUES('Boxing')");
            Sql("INSERT INTO Sports (Name) VALUES('Gymnastics')");
            Sql("INSERT INTO Sports (Name) VALUES('Archery')");
            Sql("INSERT INTO Sports (Name) VALUES('Badminton')");
            Sql("INSERT INTO Sports (Name) VALUES('Tennis')");
        }

        public override void Down()
        {
        }
    }
}
