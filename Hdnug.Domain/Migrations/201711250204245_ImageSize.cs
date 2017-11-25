namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageSize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.Image", "Width", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Image", "Width");
            DropColumn("dbo.Image", "Height");
        }
    }
}
