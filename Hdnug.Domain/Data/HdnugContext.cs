using System.Data.Entity;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Mapping;
using Highway.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hdnug.Domain.Data
{
    public class HdnugContext : DataContext
    {
        public HdnugContext()
            : base("Data Source=(localdb)\\v11.0;Initial Catalog=Hdnug;Integrated Security=True", new MappingConfiguration())
        {
        }

        public DbSet<IdentityUserClaim> Claims { get; set; }
        public DbSet<IdentityUserLogin> Logins { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<PrizeSponsorship> PrizeSponsorships { get; set; } 
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
