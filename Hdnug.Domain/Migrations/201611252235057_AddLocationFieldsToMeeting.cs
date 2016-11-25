namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationFieldsToMeeting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meeting", "LocationName", c => c.String());
            AddColumn("dbo.Meeting", "LocationAddress1", c => c.String());
            AddColumn("dbo.Meeting", "LocationAddress2", c => c.String());
            AddColumn("dbo.Meeting", "LocationCity", c => c.String());
            AddColumn("dbo.Meeting", "LocationState", c => c.String());
            AddColumn("dbo.Meeting", "LocationZip", c => c.String());
            DropColumn("dbo.Meeting", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meeting", "Location", c => c.String());
            DropColumn("dbo.Meeting", "LocationZip");
            DropColumn("dbo.Meeting", "LocationState");
            DropColumn("dbo.Meeting", "LocationCity");
            DropColumn("dbo.Meeting", "LocationAddress2");
            DropColumn("dbo.Meeting", "LocationAddress1");
            DropColumn("dbo.Meeting", "LocationName");
        }
    }
}
