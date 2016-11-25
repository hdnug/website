namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePresentationDateFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presentation", "PresentationStartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Presentation", "PresentationEndDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Presentation", "PresentationDate");
            DropColumn("dbo.Presentation", "StartTime");
            DropColumn("dbo.Presentation", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Presentation", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Presentation", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Presentation", "PresentationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Presentation", "PresentationEndDateTime");
            DropColumn("dbo.Presentation", "PresentationStartDateTime");
        }
    }
}
