namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "Id", "dbo.Meeting");
            DropIndex("dbo.Location", new[] { "Id" });
            DropPrimaryKey("dbo.Location");
            AddColumn("dbo.Meeting", "LocationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Location", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Location", "Id");
            CreateIndex("dbo.Meeting", "LocationId");
            AddForeignKey("dbo.Meeting", "LocationId", "dbo.Location", "Id", cascadeDelete: true);
            DropColumn("dbo.Meeting", "LocationName");
            DropColumn("dbo.Meeting", "LocationAddress1");
            DropColumn("dbo.Meeting", "LocationAddress2");
            DropColumn("dbo.Meeting", "LocationCity");
            DropColumn("dbo.Meeting", "LocationState");
            DropColumn("dbo.Meeting", "LocationZip");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meeting", "LocationZip", c => c.String());
            AddColumn("dbo.Meeting", "LocationState", c => c.String());
            AddColumn("dbo.Meeting", "LocationCity", c => c.String());
            AddColumn("dbo.Meeting", "LocationAddress2", c => c.String());
            AddColumn("dbo.Meeting", "LocationAddress1", c => c.String());
            AddColumn("dbo.Meeting", "LocationName", c => c.String());
            DropForeignKey("dbo.Meeting", "LocationId", "dbo.Location");
            DropIndex("dbo.Meeting", new[] { "LocationId" });
            DropPrimaryKey("dbo.Location");
            AlterColumn("dbo.Location", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Meeting", "LocationId");
            AddPrimaryKey("dbo.Location", "Id");
            CreateIndex("dbo.Location", "Id");
            AddForeignKey("dbo.Location", "Id", "dbo.Meeting", "Id");
        }
    }
}
