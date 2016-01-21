namespace Hdnug.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AltText = c.String(),
                        Caption = c.String(),
                        ImageUrl = c.String(),
                        Height = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Meeting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        MeetingDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presentation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        PresentationDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Speaker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Bio = c.String(),
                        WebSiteUrl = c.String(),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Image", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Sponsor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        TagLine = c.String(),
                        SponsorMessage = c.String(),
                        WebSiteUrl = c.String(),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Image", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.PrizeSponsorship",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SponsorId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sponsor", t => t.SponsorId)
                .Index(t => t.SponsorId);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Image", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PresentationSpeakers",
                c => new
                    {
                        Presentation_Id = c.Int(nullable: false),
                        Speaker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Presentation_Id, t.Speaker_Id })
                .ForeignKey("dbo.Presentation", t => t.Presentation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Speaker", t => t.Speaker_Id, cascadeDelete: true)
                .Index(t => t.Presentation_Id)
                .Index(t => t.Speaker_Id);
            
            CreateTable(
                "dbo.MeetingPresentations",
                c => new
                    {
                        Meeting_Id = c.Int(nullable: false),
                        Presentation_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meeting_Id, t.Presentation_Id })
                .ForeignKey("dbo.Meeting", t => t.Meeting_Id, cascadeDelete: true)
                .ForeignKey("dbo.Presentation", t => t.Presentation_Id, cascadeDelete: true)
                .Index(t => t.Meeting_Id)
                .Index(t => t.Presentation_Id);
            
            CreateTable(
                "dbo.MeetingSponsors",
                c => new
                    {
                        Meeting_Id = c.Int(nullable: false),
                        Sponsor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meeting_Id, t.Sponsor_Id })
                .ForeignKey("dbo.Meeting", t => t.Meeting_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sponsor", t => t.Sponsor_Id, cascadeDelete: true)
                .Index(t => t.Meeting_Id)
                .Index(t => t.Sponsor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slider", "ImageId", "dbo.Image");
            DropForeignKey("dbo.PrizeSponsorship", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.MeetingSponsors", "Sponsor_Id", "dbo.Sponsor");
            DropForeignKey("dbo.MeetingSponsors", "Meeting_Id", "dbo.Meeting");
            DropForeignKey("dbo.Sponsor", "ImageId", "dbo.Image");
            DropForeignKey("dbo.MeetingPresentations", "Presentation_Id", "dbo.Presentation");
            DropForeignKey("dbo.MeetingPresentations", "Meeting_Id", "dbo.Meeting");
            DropForeignKey("dbo.PresentationSpeakers", "Speaker_Id", "dbo.Speaker");
            DropForeignKey("dbo.PresentationSpeakers", "Presentation_Id", "dbo.Presentation");
            DropForeignKey("dbo.Speaker", "ImageId", "dbo.Image");
            DropForeignKey("dbo.Claims", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropIndex("dbo.MeetingSponsors", new[] { "Sponsor_Id" });
            DropIndex("dbo.MeetingSponsors", new[] { "Meeting_Id" });
            DropIndex("dbo.MeetingPresentations", new[] { "Presentation_Id" });
            DropIndex("dbo.MeetingPresentations", new[] { "Meeting_Id" });
            DropIndex("dbo.PresentationSpeakers", new[] { "Speaker_Id" });
            DropIndex("dbo.PresentationSpeakers", new[] { "Presentation_Id" });
            DropIndex("dbo.Slider", new[] { "ImageId" });
            DropIndex("dbo.PrizeSponsorship", new[] { "SponsorId" });
            DropIndex("dbo.Sponsor", new[] { "ImageId" });
            DropIndex("dbo.Speaker", new[] { "ImageId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.Claims", new[] { "User_Id" });
            DropTable("dbo.MeetingSponsors");
            DropTable("dbo.MeetingPresentations");
            DropTable("dbo.PresentationSpeakers");
            DropTable("dbo.Member");
            DropTable("dbo.Slider");
            DropTable("dbo.PrizeSponsorship");
            DropTable("dbo.Sponsor");
            DropTable("dbo.Speaker");
            DropTable("dbo.Presentation");
            DropTable("dbo.Meeting");
            DropTable("dbo.Image");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Logins");
            DropTable("dbo.Users");
            DropTable("dbo.Claims");
        }
    }
}
