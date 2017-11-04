namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "MapUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Location", "MapUrl");
        }
    }
}
