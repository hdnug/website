namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImageId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Speaker", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Sponsor", "ImageId", "dbo.Image");
            DropPrimaryKey("dbo.Image");
            DropColumn("dbo.Image", "ImageId");
            AddColumn("dbo.Image", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Image", "Id");
            AddForeignKey("dbo.Speaker", "ImageId", "dbo.Image", "Id");
            AddForeignKey("dbo.Sponsor", "ImageId", "dbo.Image", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Image", "ImageId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Sponsor", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Speaker", "ImageId", "dbo.Image");
            DropPrimaryKey("dbo.Image");
            DropColumn("dbo.Image", "Id");
            AddPrimaryKey("dbo.Image", "ImageId");
            AddForeignKey("dbo.Sponsor", "ImageId", "dbo.Image", "ImageId", cascadeDelete: true);
            AddForeignKey("dbo.Speaker", "ImageId", "dbo.Image", "ImageId");
        }
    }
}
