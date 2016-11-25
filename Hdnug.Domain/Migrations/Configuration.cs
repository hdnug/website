using System;
using System.Collections.Generic;
using System.Linq;
using Hdnug.Domain.Constants;
using Hdnug.Domain.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

namespace Hdnug.Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.HdnugContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HdnugContext";
        }

        protected override void Seed(Data.HdnugContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            #region Roles and Users

            if (!context.Roles.Any(r => r.Name == Roles.ApplicationAdministrator))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = Roles.ApplicationAdministrator };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "AppAdmin"))
            {
                var store = new UserStore<IdentityUser>(context);
                var manager = new UserManager<IdentityUser>(store);
                var user = new IdentityUser { UserName = "AppAdmin" };

                manager.Create(user, "ChangeMe1234!");
                manager.AddToRole(user.Id, Roles.ApplicationAdministrator);
            }

            #endregion

            context.Images.AddOrUpdate(
                i => i.ImageId,
                new Image
                {
                    ImageId = 1,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Logo,
                    ImageUrl = "Content/Images/Sponsor/improving1.png"
                },
                new Image
                {
                    ImageId = 2,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Logo,
                    ImageUrl = "Content/Images/Sponsor/improving2.png"
                },
                new Image
                {
                    ImageId = 3,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Logo,
                    ImageUrl = "Content/Images/Sponsor/improving3.png"
                },
                new Image
                {
                    ImageId = 4,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Logo,
                    ImageUrl = "Content/Images/Sponsor/improving4.png"
                },
                new Image
                {
                    ImageId = 5,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Logo,
                    ImageUrl = "Content/Images/Sponsor/improving5.png"
                },
                new Image
                {
                    ImageId = 6,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Logo,
                    ImageUrl = "Content/Images/Sponsor/improving6.png"
                },
                new Image
                {
                    ImageId = 7,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Logo,
                    ImageUrl = "Content/Images/Sponsor/improving7.png"
                },
                new Image
                {
                    ImageId = 8,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Profile,
                    ImageUrl = "Content/Images/Sponsor/improving8.png"
                },
                new Image
                {
                    ImageId = 9,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Profile,
                    ImageUrl = "Content/Images/Sponsor/improving9.png"
                },
                new Image
                {
                    ImageId = 10,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Profile,
                    ImageUrl = "Content/Images/Sponsor/improvin10.png"
                },
                new Image
                {
                    ImageId = 11,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Profile,
                    ImageUrl = "Content/Images/Sponsor/improving11.png"
                },
                new Image
                {
                    ImageId = 12,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 400,
                    Width = 1000,
                    ImageType = ImageType.Profile,
                    ImageUrl = "Content/Images/Sponsor/improving12.png"
                },
                new Image
                {
                    ImageId = 13,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 300,
                    Width = 1000,
                    ImageType = ImageType.Slider,
                    ImageUrl = "Content/Images/Site/IMG_0117.jpg"
                },
                new Image
                {
                    ImageId = 14,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 300,
                    Width = 1000,
                    ImageType = ImageType.Slider,
                    ImageUrl = "Content/Images/Site/IMG_1626.jpg"
                },
                new Image
                {
                    ImageId = 15,
                    Title = "My Title",
                    AltText = "AltText",
                    Caption = "My Clever Caption",
                    Height = 300,
                    Width = 1000,
                    ImageType = ImageType.Slider,
                    ImageUrl = "Content/Images/Site/IMG_1782.jpg"
                }
                );

            context.Meetings.AddOrUpdate(
                m => m.Id,
                new Meeting
                {
                    Id = 1,
                    Title = "June Meeting",
                    Description =
                        "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa.",
                    MeetingStartDateTime = new DateTime(2014, 06, 12, 18, 30, 00),
                    MeetingEndDateTime = new DateTime(2014, 06, 12, 20, 30, 00),
                    LocationName = "Microsoft Technology Center - Houston",
                    LocationAddress1 = "750 Town and Country Blvd.",
                    LocationAddress2 = "Suite 1000",
                    LocationCity = "Houston",
                    LocationState = "TX",
                    LocationZip = "77024"
                },
                new Meeting
                {
                    Id = 2,
                    Title = "July Meeting",
                    Description =
                        "Boudin aliqua adipisicing rump corned beef. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami.",
                    MeetingStartDateTime = new DateTime(2014, 07, 10, 18, 30, 00),
                    MeetingEndDateTime = new DateTime(2014, 07, 10, 20, 30, 00),
                    LocationName = "Microsoft Technology Center - Houston",
                    LocationAddress1 = "750 Town and Country Blvd.",
                    LocationAddress2 = "Suite 1000",
                    LocationCity = "Houston",
                    LocationState = "TX",
                    LocationZip = "77024"
                },
                new Meeting
                {
                    Id = 3,
                    Title = "August Meeting",
                    Description =
                        "Pork drumstick turkey fugiat. Tri-tip elit turducken pork chop in. Swine short ribs meatball irure bacon nulla pork belly cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami.",
                    MeetingStartDateTime = new DateTime(2014, 08, 07, 18, 30, 00),
                    MeetingEndDateTime = new DateTime(2014, 08, 07, 20, 30, 00),
                    LocationName = "Microsoft Technology Center - Houston",
                    LocationAddress1 = "750 Town and Country Blvd.",
                    LocationAddress2 = "Suite 1000",
                    LocationCity = "Houston",
                    LocationState = "TX",
                    LocationZip = "77024"
                },
                new Meeting
                {
                    Id = 4,
                    Title = "November Meeting",
                    Description =
                        "Pork drumstick turkey fugiat. Tri-tip elit turducken pork chop in. Swine short ribs meatball irure bacon nulla pork belly cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa.",
                    MeetingStartDateTime = new DateTime(2014, 11, 11, 18, 30, 00),
                    MeetingEndDateTime = new DateTime(2014, 11, 11, 20, 30, 00),
                    LocationName = "Microsoft Technology Center - Houston",
                    LocationAddress1 = "750 Town and Country Blvd.",
                    LocationAddress2 = "Suite 1000",
                    LocationCity = "Houston",
                    LocationState = "TX",
                    LocationZip = "77024"
                }
                );

            context.SaveChanges();

            context.Sponsors.AddOrUpdate(
                s => s.Id,
                new Sponsor
                {
                    Id = 1,
                    Name = "Improving Enterprises",
                    Logo = context.Images.Single(t => t.ImageId == 1),
                    Contact = "Christina Liles",
                    Email = "christina.liles@improvingenterprises.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are the best ever!",
                    TagLine = "Improving...that's what we do.",
                    WebSiteUrl = "www.improvingenterprises.com",
                    MeetingId = 1
                },
                new Sponsor
                {
                    Id = 2,
                    Name = "Whitaker IT",
                    Logo = context.Images.Single(t => t.ImageId == 2),
                    Contact = "Lisa Gibbons",
                    Email = "lgibbons@whitaker.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We really rock!",
                    TagLine = "Finding people for IT problems.",
                    WebSiteUrl = "www.whitakerit.com",
                    MeetingId = 2
                },
                new Sponsor
                {
                    Id = 3,
                    Name = "Waste Management",
                    Logo = context.Images.Single(t => t.ImageId == 3),
                    Contact = "Oscar Grouch",
                    Email = "oscar.grouch@wastemanagement.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are an ok company.",
                    TagLine = "Fixing the world's trash problems one bananna peel at a time.",
                    WebSiteUrl = "www.wastemanagement.com",
                    MeetingId = 3
                },
                new Sponsor
                {
                    Id = 4,
                    Name = "Strategic Careers",
                    Logo = context.Images.Single(t => t.ImageId == 4),
                    Contact = "Brad Jefferson",
                    Email = "bradJ@strategic.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are so awesome!",
                    TagLine = "We have good strategies for resources.",
                    WebSiteUrl = "www.strategic.com",
                    MeetingId = 4
                },
                new Sponsor
                {
                    Id = 5,
                    Name = "O'reilly",
                    Logo = context.Images.Single(t => t.ImageId == 5),
                    Contact = "Bill Bixby",
                    Email = "bb@gmail.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We have the most books",
                    TagLine = "Books for days!.",
                    WebSiteUrl = "www.oreilly.com"
                },
                new Sponsor
                {
                    Id = 6,
                    Name = "PluralSite",
                    Logo = context.Images.Single(t => t.ImageId == 6),
                    Contact = "Brad Jefferson",
                    Email = "bradJ@strategic.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are the best!",
                    TagLine = "Improving...that's what we do.",
                    WebSiteUrl = "www.improvingenterprises.com"
                },
                new Sponsor
                {
                    Id = 7,
                    Name = "Microsoft",
                    Logo = context.Images.Single(t => t.ImageId == 7),
                    Contact = "Brad Jefferson",
                    Email = "bradJ@strategic.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "Our software is the really the best ever.",
                    TagLine = "Why are we so good?!",
                    WebSiteUrl = "www.microsoft.com"
                },
                new Sponsor
                {
                    Id = 8,
                    Name = "Amazon",
                    Logo = context.Images.Single(t => t.ImageId == 8),
                    Contact = "Brad Jefferson",
                    Email = "bradJ@strategic.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are just so freaking huge!",
                    TagLine = "We got stuff that hasn't even been invented.",
                    WebSiteUrl = "www.amazon.com"
                }
                );

            context.PrizeSponsorships.AddOrUpdate(
                p => p.Id,
                new PrizeSponsorship
                {
                    Id = 1,
                    SponsorId = 5,
                    StartDate = new DateTime(2014, 01, 01),
                    EndDate = new DateTime(2014, 12, 31)
                },
                new PrizeSponsorship
                {
                    Id = 1,
                    SponsorId = 7,
                    StartDate = new DateTime(2014, 01, 01),
                    EndDate = new DateTime(2014, 12, 31)
                }
                );

            context.Presentations.AddOrUpdate(
                new Presentation
                {
                    Id = 1,
                    Title = "My Awesome talk!",
                    Description =
                        "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa.",
                    PresentationDate = new DateTime(2014, 06, 12),
                    StartTime = new DateTime(2014, 06, 12, 18, 30, 00),
                    EndTime = new DateTime(2014, 06, 12, 20, 30, 00),
                    Location = "Challenger Room",
                    Url = "/Presentations/presentation.ppt",
                    MeetingId = 1
                },
                new Presentation
                {
                    Id = 2,
                    Title = "How to code in .NET",
                    Description =
                        "Boudin aliqua adipisicing rump corned beef. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami.",
                    PresentationDate = new DateTime(2014, 06, 12),
                    StartTime = new DateTime(2014, 06, 12, 18, 30, 00),
                    EndTime = new DateTime(2014, 06, 12, 20, 30, 00),
                    Location = "Challenger Room",
                    Url = "/Presentations/presentation.ppt",
                    MeetingId = 2
                },
                new Presentation
                {
                    Id = 3,
                    Title = "Why .NET really Rocks!",
                    Description =
                        "Pork drumstick turkey fugiat. Tri-tip elit turducken pork chop in. Swine short ribs meatball irure bacon nulla pork belly cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami.",
                    PresentationDate = new DateTime(2014, 06, 12),
                    StartTime = new DateTime(2014, 06, 12, 18, 30, 00),
                    EndTime = new DateTime(2014, 06, 12, 20, 30, 00),
                    Location = "Challenger Room",
                    Url = "/Presentations/presentation.ppt",
                    MeetingId = 3
                },
                new Presentation
                {
                    Id = 4,
                    Title = "Welcome to Fight Club with Knockout.js",
                    Description =
                        "Pork drumstick turkey fugiat. Tri-tip elit turducken pork chop in. Swine short ribs meatball irure bacon nulla pork belly cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa.",
                    PresentationDate = new DateTime(2014, 06, 12),
                    StartTime = new DateTime(2014, 06, 12, 18, 30, 00),
                    EndTime = new DateTime(2014, 06, 12, 20, 30, 00),
                    Location = "Challenger Room",
                    Url = "/Presentations/presentation.ppt",
                    MeetingId = 4
                }
                );

            context.Speakers.AddOrUpdate(
                s => s.Id,
                new Speaker
                {
                    Id = 1,
                    Name = "Bob Martin",
                    Email = "unclebob@objectmentor.com",
                    Phone = "555-555-5555",
                    Photo = context.Images.Single(t => t.ImageId == 9),
                    Bio = "Me, me, me....all about me!",
                    WebSiteUrl = "www.myblog.com",
                    PresentationId = 1
                },
                new Speaker
                {
                    Id = 2,
                    Name = "Scott Guthrie",
                    Email = "scottgnu@microsoft.com",
                    Phone = "555-555-5555",
                    Photo = context.Images.Single(t => t.ImageId == 10),
                    Bio = "Me, me, me....all about me!...Me too!",
                    WebSiteUrl = "www.myblog.com",
                    PresentationId = 2
                },
                new Speaker
                {
                    Id = 3,
                    Name = "Scott Hanselman",
                    Email = "scott@hanselman.com",
                    Phone = "555-555-5555",
                    Photo = context.Images.Single(t => t.ImageId == 11),
                    Bio = "Me, me, me....all about me!...Me too!...Ha-ha-ha!!!!",
                    WebSiteUrl = "www.myblog.com",
                    PresentationId = 3
                }
                );

            context.SaveChanges();

        }
    }
}
