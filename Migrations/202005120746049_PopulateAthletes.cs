namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateAthletes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Athletes (Name,SportId,Weight,Height,Age) VALUES('Andriy', 5, 88, 193, 17)");
            Sql("INSERT INTO Athletes (Name,SportId,Weight,Height,Age) VALUES('Maks', 1, 80, 187, 18)");
            Sql("INSERT INTO Athletes (Name,SportId,Weight,Height,Age) VALUES('Danya', 2, 70, 169, 17)");
        }

        public override void Down()
        {
        }
    }
}
