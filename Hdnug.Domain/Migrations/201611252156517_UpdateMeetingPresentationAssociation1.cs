namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMeetingPresentationAssociation1 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.Presentation", name: "Meeting_Id", newName: "MeetingId");
            //RenameIndex(table: "dbo.Presentation", name: "IX_Meeting_Id", newName: "IX_MeetingId");
        }
        
        public override void Down()
        {
            //RenameIndex(table: "dbo.Presentation", name: "IX_MeetingId", newName: "IX_Meeting_Id");
            //RenameColumn(table: "dbo.Presentation", name: "MeetingId", newName: "Meeting_Id");
        }
    }
}
