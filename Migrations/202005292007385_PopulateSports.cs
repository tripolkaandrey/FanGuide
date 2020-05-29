namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateSports : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Basketball',1)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Volleyball',1)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Football',1)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Hockey',1)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Sambo',0)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Karate',0)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Boxing',0)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Gymnastics',0)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Archery',0)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Badminton',0)");
            Sql("INSERT INTO Sports (Name,isTeamSport) VALUES('Tennis',0)");
        }

        public override void Down()
        {
        }
    }
}
