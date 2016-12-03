namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSizeFieldsFromImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Image", "Height");
            DropColumn("dbo.Image", "Width");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Image", "Width", c => c.Int(nullable: false));
            AddColumn("dbo.Image", "Height", c => c.Int(nullable: false));
        }
    }
}
