namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorSpeakerName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speaker", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Speaker", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Speaker", "Phone", c => c.String(maxLength: 20));
            DropColumn("dbo.Speaker", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Speaker", "Name", c => c.String());
            AlterColumn("dbo.Speaker", "Phone", c => c.String());
            DropColumn("dbo.Speaker", "LastName");
            DropColumn("dbo.Speaker", "FirstName");
        }
    }
}
