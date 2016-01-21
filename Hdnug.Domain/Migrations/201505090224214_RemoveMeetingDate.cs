namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMeetingDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meeting", "MeetingStartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Meeting", "MeetingEndDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Meeting", "MeetingDate");
            DropColumn("dbo.Meeting", "StartTime");
            DropColumn("dbo.Meeting", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meeting", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Meeting", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Meeting", "MeetingDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Meeting", "MeetingEndDateTime");
            DropColumn("dbo.Meeting", "MeetingStartDateTime");
        }
    }
}
