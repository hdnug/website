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
            AutomaticMigrationsEnabled = true;
            
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

            context.Locations.AddOrUpdate(i => i.Id, new Location()
            {
                Id=1, 
                Name = "Microsoft Houston Tech Center", 
                Address1 = "750 Town and Country Blvd", 
                Address2 = "Suite 1000", 
                City = "Houston", 
                State = "Texas", 
                PostalCode = "77024"

            });

            context.Locations.AddOrUpdate(i => i.Id, new Location()
            {
                Id = 2,
                Name = "Improving Houston",
                Address1 = "10111 Richmond Ave",
                Address2 = "Suite 100",
                City = "Houston",
                State = "Texas",
                PostalCode = "77042"

            });



            context.Images.AddOrUpdate(
                i => i.Id,
                new Image
                {
                    Id = 1,
                    Title = "Dot Net Rocks in Houston with Venkat",
                    AltText = "Dot Net Rocks in Houston with Venkat",
                    Caption = "Dot Net Rocks in Houston with Venkat",
                    ImageType = ImageType.Slider,
                    ImageUrl = "~/Content/Images/Site/IMG_0117.jpg"
                },
                new Image
                {
                    Id = 2,
                    Title = "June Meeting",
                    AltText = "June Meeting",
                    Caption = "June Meeting",
                    ImageType = ImageType.Slider,
                    ImageUrl = "~/Content/Images/Site/IMG_1626.jpg"
                },
                new Image
                {
                    Id = 3,
                    Title = "Discussion Panel",
                    AltText = "Discussion Panel",
                    Caption = "Discussion Panel",
                    ImageType = ImageType.Slider,
                    ImageUrl = "~/Content/Images/Site/IMG_1782.jpg"
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

            context.Sponsors.AddOrUpdate(
                s => s.Id,
                new Sponsor
                {
                    Id = 1,
                    Name = "Improving Enterprises",
                    Contact = "Christina Liles",
                    Email = "christina.liles@improvingenterprises.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are the best ever!",
                    TagLine = "Improving...that's what we do.",
                    WebSiteUrl = "www.improvingenterprises.com",
                },
                new Sponsor
                {
                    Id = 2,
                    Name = "Whitaker IT",
                    Contact = "Lisa Gibbons",
                    Email = "lgibbons@whitaker.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We really rock!",
                    TagLine = "Finding people for IT problems.",
                    WebSiteUrl = "www.whitakerit.com",
                },
                new Sponsor
                {
                    Id = 3,
                    Name = "Waste Management",
                    Contact = "Oscar Grouch",
                    Email = "oscar.grouch@wastemanagement.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are an ok company.",
                    TagLine = "Fixing the world's trash problems one bananna peel at a time.",
                    WebSiteUrl = "www.wastemanagement.com",
                },
                new Sponsor
                {
                    Id = 4,
                    Name = "Strategic Careers",
                    Contact = "Brad Jefferson",
                    Email = "bradJ@strategic.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are so awesome!",
                    TagLine = "We have good strategies for resources.",
                    WebSiteUrl = "www.strategic.com",
                },
                new Sponsor
                {
                    Id = 5,
                    Name = "O'reilly",
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
                    Contact = "Brad Jefferson",
                    Email = "bradJ@strategic.com",
                    Phone = "555-555-5555",
                    SponsorMessage = "We are just so freaking huge!",
                    TagLine = "We got stuff that hasn't even been invented.",
                    WebSiteUrl = "www.amazon.com"
                }
                );
            
            context.Speakers.AddOrUpdate(
                s => s.Id,
                new Speaker
                {
                    Id = 1,
                    Name = "Speaker1",
                    Email = "speaker1@aol.com",
                    Phone = "555-555-5555",
                    Bio = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa.",
                    WebSiteUrl = "www.myblog.com"
                },
                new Speaker
                {
                    Id = 2,
                    Name = "Speaker2",
                    Email = "speaker2@aol.com",
                    Phone = "555-555-5555",
                    Bio = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa.",
                    WebSiteUrl = "www.myblog.com"
                },
                new Speaker
                {
                    Id = 3,
                    Name = "Speaker3",
                    Email = "speaker3@aol.com",
                    Phone = "555-555-5555",
                    Bio = "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit.Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong.Eiusmod swine spare ribs reprehenderit culpa.",
                    WebSiteUrl = "www.myblog.com"
                }
                );

            context.SaveChanges();

            context.Presentations.AddOrUpdate(
                new Presentation
                {
                    Id = 1,
                    Title = "My Awesome talk!",
                    Description =
                        "Bacon ipsum dolor sit amet nulla ham qui sint exercitation eiusmod commodo, chuck duis velit. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa.",
                    PresentationStartDateTime = new DateTime(2014, 06, 12, 18, 30, 00),
                    PresentationEndDateTime = new DateTime(2014, 06, 12, 20, 30, 00),
                    Location = "Challenger Room",
                    Speakers = new List<Speaker>
                    {
                        context.Speakers.Single(x => x.Id == 1)
                    }
                },
                new Presentation
                {
                    Id = 2,
                    Title = "How to code in .NET",
                    Description =
                        "Boudin aliqua adipisicing rump corned beef. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami.",
                    PresentationStartDateTime = new DateTime(2014, 07, 10, 18, 30, 00),
                    PresentationEndDateTime = new DateTime(2014, 07, 10, 20, 30, 00),
                    Location = "Challenger Room",
                    Speakers = new List<Speaker>
                    {
                        context.Speakers.Single(x => x.Id == 1)
                    }
                },
                new Presentation
                {
                    Id = 3,
                    Title = "Why .NET really Rocks!",
                    Description =
                        "Pork drumstick turkey fugiat. Tri-tip elit turducken pork chop in. Swine short ribs meatball irure bacon nulla pork belly cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami.",
                    PresentationStartDateTime = new DateTime(2014, 08, 07, 18, 30, 00),
                    PresentationEndDateTime = new DateTime(2014, 08, 07, 20, 30, 00),
                    Location = "Challenger Room",
                    Speakers = new List<Speaker>
                    {
                        context.Speakers.Single(x => x.Id == 2)
                    }
                },
                new Presentation
                {
                    Id = 4,
                    Title = "Welcome to Fight Club with Knockout.js",
                    Description =
                        "Pork drumstick turkey fugiat. Tri-tip elit turducken pork chop in. Swine short ribs meatball irure bacon nulla pork belly cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Nulla corned beef sunt ball tip, qui bresaola enim jowl. Capicola short ribs minim salami nulla nostrud pastrami. Aute in reprehenderit, dolore aliqua non est magna in labore pig pork biltong. Eiusmod swine spare ribs reprehenderit culpa.",
                    PresentationStartDateTime = new DateTime(2014, 11, 11, 18, 30, 00),
                    PresentationEndDateTime = new DateTime(2014, 11, 11, 20, 30, 00),
                    Location = "Challenger Room",
                    Speakers = new List<Speaker>
                    {
                        context.Speakers.Single(x => x.Id == 3)
                    }
                }
                );

            context.SaveChanges();

            context.Meetings.AddOrUpdate(
                m => m.Id,
                new Meeting
                {
                    Id = 1,
                    Title = "Meeting #1",
                    Description = "June 2014 Meeting",
                    MeetingStartDateTime = new DateTime(2014, 06, 12, 18, 30, 00),
                    MeetingEndDateTime = new DateTime(2014, 06, 12, 20, 30, 00),
                    LocationId = 1, 
                    Sponsors = new List<Sponsor>
                    {
                        context.Sponsors.Single(x => x.Id == 1)
                    },
                    Presentations = new List<Presentation>
                    {
                        context.Presentations.Single(x => x.Id == 1)
                    }
                },
                new Meeting
                {
                    Id = 2,
                    Title = "Meeting #2",
                    Description = "July 2014 Meeting",
                    MeetingStartDateTime = new DateTime(2014, 07, 10, 18, 30, 00),
                    MeetingEndDateTime = new DateTime(2014, 07, 10, 20, 30, 00),
                    LocationId = 1,
                    Sponsors = new List<Sponsor>
                    {
                        context.Sponsors.Single(x => x.Id == 2)
                    },
                    Presentations = new List<Presentation>
                    {
                        context.Presentations.Single(x => x.Id == 2)
                    }
                },
                new Meeting
                {
                    Id = 3,
                    Title = "Meeting #3",
                    Description = "August 2014 Meeting",
                    MeetingStartDateTime = new DateTime(2014, 08, 07, 18, 30, 00),
                    MeetingEndDateTime = new DateTime(2014, 08, 07, 20, 30, 00),
                    LocationId = 1,
                    Sponsors = new List<Sponsor>
                    {
                        context.Sponsors.Single(x => x.Id == 3)
                    },
                    Presentations = new List<Presentation>
                    {
                        context.Presentations.Single(x => x.Id == 3)
                    }
                },
                new Meeting
                {
                    Id = 4,
                    Title = "Meeting #4",
                    Description = "November 2014 Meeting",
                    MeetingStartDateTime = new DateTime(2014, 11, 11, 18, 30, 00),
                    MeetingEndDateTime = new DateTime(2014, 11, 11, 20, 30, 00),
                    LocationId = 2,
                    Sponsors = new List<Sponsor>
                    {
                        context.Sponsors.Single(x => x.Id == 4)
                    },
                    Presentations = new List<Presentation>
                    {
                        context.Presentations.Single(x => x.Id == 4)
                    }
                }
                );

            context.SaveChanges();
        }
    }
}
