namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMeetingSponsorAssociation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeetingSponsors", "Meeting_Id", "dbo.Meeting");
            DropForeignKey("dbo.MeetingSponsors", "Sponsor_Id", "dbo.Sponsor");
            DropIndex("dbo.MeetingSponsors", new[] { "Meeting_Id" });
            DropIndex("dbo.MeetingSponsors", new[] { "Sponsor_Id" });
            AddColumn("dbo.Sponsor", "MeetingId", c => c.Int());
            CreateIndex("dbo.Sponsor", "MeetingId");
            AddForeignKey("dbo.Sponsor", "MeetingId", "dbo.Meeting", "Id");
            DropTable("dbo.MeetingSponsors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MeetingSponsors",
                c => new
                    {
                        Meeting_Id = c.Int(nullable: false),
                        Sponsor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meeting_Id, t.Sponsor_Id });
            
            DropForeignKey("dbo.Sponsor", "MeetingId", "dbo.Meeting");
            DropIndex("dbo.Sponsor", new[] { "MeetingId" });
            DropColumn("dbo.Sponsor", "MeetingId");
            CreateIndex("dbo.MeetingSponsors", "Sponsor_Id");
            CreateIndex("dbo.MeetingSponsors", "Meeting_Id");
            AddForeignKey("dbo.MeetingSponsors", "Sponsor_Id", "dbo.Sponsor", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MeetingSponsors", "Meeting_Id", "dbo.Meeting", "Id", cascadeDelete: true);
        }
    }
}
