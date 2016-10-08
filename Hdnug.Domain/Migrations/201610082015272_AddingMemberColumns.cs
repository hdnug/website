namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMemberColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "FirstName", c => c.String());
            AddColumn("dbo.Member", "LastName", c => c.String());
            AddColumn("dbo.Member", "Company", c => c.String());
            DropColumn("dbo.Member", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Member", "Name", c => c.String());
            DropColumn("dbo.Member", "Company");
            DropColumn("dbo.Member", "LastName");
            DropColumn("dbo.Member", "FirstName");
        }
    }
}
