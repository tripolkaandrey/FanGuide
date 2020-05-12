﻿namespace FanGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttributeToSportName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sports", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sports", "Name", c => c.String(nullable: false));
        }
    }
}
