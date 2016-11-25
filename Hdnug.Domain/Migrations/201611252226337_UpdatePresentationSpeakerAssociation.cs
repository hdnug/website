namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePresentationSpeakerAssociation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PresentationSpeakers", "Presentation_Id", "dbo.Presentation");
            DropForeignKey("dbo.PresentationSpeakers", "Speaker_Id", "dbo.Speaker");
            DropIndex("dbo.PresentationSpeakers", new[] { "Presentation_Id" });
            DropIndex("dbo.PresentationSpeakers", new[] { "Speaker_Id" });
            AddColumn("dbo.Speaker", "PresentationId", c => c.Int());
            CreateIndex("dbo.Speaker", "PresentationId");
            AddForeignKey("dbo.Speaker", "PresentationId", "dbo.Presentation", "Id");
            DropTable("dbo.PresentationSpeakers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PresentationSpeakers",
                c => new
                    {
                        Presentation_Id = c.Int(nullable: false),
                        Speaker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Presentation_Id, t.Speaker_Id });
            
            DropForeignKey("dbo.Speaker", "PresentationId", "dbo.Presentation");
            DropIndex("dbo.Speaker", new[] { "PresentationId" });
            DropColumn("dbo.Speaker", "PresentationId");
            CreateIndex("dbo.PresentationSpeakers", "Speaker_Id");
            CreateIndex("dbo.PresentationSpeakers", "Presentation_Id");
            AddForeignKey("dbo.PresentationSpeakers", "Speaker_Id", "dbo.Speaker", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PresentationSpeakers", "Presentation_Id", "dbo.Presentation", "Id", cascadeDelete: true);
        }
    }
}
