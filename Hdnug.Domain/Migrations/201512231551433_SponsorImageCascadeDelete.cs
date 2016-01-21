namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SponsorImageCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sponsor", "ImageId", "dbo.Image");
            AddForeignKey("dbo.Sponsor", "ImageId", "dbo.Image", "ImageId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sponsor", "ImageId", "dbo.Image");
            AddForeignKey("dbo.Sponsor", "ImageId", "dbo.Image", "ImageId");
        }
    }
}
