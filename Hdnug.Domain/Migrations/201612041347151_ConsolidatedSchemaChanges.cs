namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsolidatedSchemaChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Speaker", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Sponsor", "ImageId", "dbo.Image");
            DropPrimaryKey("dbo.Image");
            DropColumn("dbo.Image", "ImageId");
            DropColumn("dbo.Image", "Height");
            DropColumn("dbo.Image", "Width");
            DropColumn("dbo.Meeting", "Location");
            DropColumn("dbo.Presentation", "PresentationDate");
            DropColumn("dbo.Presentation", "StartTime");
            DropColumn("dbo.Presentation", "EndTime");
            AddColumn("dbo.Image", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Meeting", "LocationName", c => c.String());
            AddColumn("dbo.Meeting", "LocationAddress1", c => c.String());
            AddColumn("dbo.Meeting", "LocationAddress2", c => c.String());
            AddColumn("dbo.Meeting", "LocationCity", c => c.String());
            AddColumn("dbo.Meeting", "LocationState", c => c.String());
            AddColumn("dbo.Meeting", "LocationZip", c => c.String());
            AddColumn("dbo.Presentation", "PresentationStartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Presentation", "PresentationEndDateTime", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.Image", "Id");
            AddForeignKey("dbo.Speaker", "ImageId", "dbo.Image", "Id");
            AddForeignKey("dbo.Sponsor", "ImageId", "dbo.Image", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Presentation", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Presentation", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Presentation", "PresentationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Meeting", "Location", c => c.String());
            AddColumn("dbo.Image", "Width", c => c.Int(nullable: false));
            AddColumn("dbo.Image", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.Image", "ImageId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Sponsor", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Speaker", "ImageId", "dbo.Image");
            DropPrimaryKey("dbo.Image");
            DropColumn("dbo.Presentation", "PresentationEndDateTime");
            DropColumn("dbo.Presentation", "PresentationStartDateTime");
            DropColumn("dbo.Meeting", "LocationZip");
            DropColumn("dbo.Meeting", "LocationState");
            DropColumn("dbo.Meeting", "LocationCity");
            DropColumn("dbo.Meeting", "LocationAddress2");
            DropColumn("dbo.Meeting", "LocationAddress1");
            DropColumn("dbo.Meeting", "LocationName");
            DropColumn("dbo.Image", "Id");
            AddPrimaryKey("dbo.Image", "ImageId");
            AddForeignKey("dbo.Sponsor", "ImageId", "dbo.Image", "ImageId", cascadeDelete: true);
            AddForeignKey("dbo.Speaker", "ImageId", "dbo.Image", "ImageId");
        }
    }
}
