namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrizeSponsorshipOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrizeSponsorship", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrizeSponsorship", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
