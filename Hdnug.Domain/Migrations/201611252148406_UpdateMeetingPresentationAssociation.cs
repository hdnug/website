namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMeetingPresentationAssociation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeetingPresentations", "Meeting_Id", "dbo.Meeting");
            DropForeignKey("dbo.MeetingPresentations", "Presentation_Id", "dbo.Presentation");
            DropIndex("dbo.MeetingPresentations", new[] { "Meeting_Id" });
            DropIndex("dbo.MeetingPresentations", new[] { "Presentation_Id" });
            AddColumn("dbo.Presentation", "MeetingId", c => c.Int());
            CreateIndex("dbo.Presentation", "MeetingId");
            AddForeignKey("dbo.Presentation", "MeetingId", "dbo.Meeting", "Id");
            DropTable("dbo.MeetingPresentations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MeetingPresentations",
                c => new
                    {
                        Meeting_Id = c.Int(nullable: false),
                        Presentation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meeting_Id, t.Presentation_Id });
            
            DropForeignKey("dbo.Presentation", "MeetingId", "dbo.Meeting");
            DropIndex("dbo.Presentation", new[] { "MeetingId" });
            DropColumn("dbo.Presentation", "MeetingId");
            CreateIndex("dbo.MeetingPresentations", "Presentation_Id");
            CreateIndex("dbo.MeetingPresentations", "Meeting_Id");
            AddForeignKey("dbo.MeetingPresentations", "Presentation_Id", "dbo.Presentation", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MeetingPresentations", "Meeting_Id", "dbo.Meeting", "Id", cascadeDelete: true);
        }
    }
}
