namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateTeamRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Point guard',1)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Shooting guard',1)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Small forward',1)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Power forward',1)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Setter',2)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Outside Hitter',2)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Middle Blocker',2)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Libero',2)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Opposite',2)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Goalkeeper',3)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Defender',3)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Midfielder',3)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Forward',3)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Striker',3)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Forward',4)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Defense',4)");
            Sql("INSERT INTO TeamRoles (Name,SportId) VALUES('Goalie',4)");
        }

        public override void Down()
        {
        }
    }
}
