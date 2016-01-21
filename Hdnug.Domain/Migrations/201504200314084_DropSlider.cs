namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropSlider : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Slider", "ImageId", "dbo.Image");
            DropIndex("dbo.Slider", new[] { "ImageId" });
            AddColumn("dbo.Image", "ImageType", c => c.Short(nullable: false));
            DropTable("dbo.Slider");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId);
            
            DropColumn("dbo.Image", "ImageType");
            CreateIndex("dbo.Slider", "ImageId");
            AddForeignKey("dbo.Slider", "ImageId", "dbo.Image", "ImageId");
        }
    }
}
