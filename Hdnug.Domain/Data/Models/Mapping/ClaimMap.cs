using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Hdnug.Domain.Data.Models.Mapping
{
    public class ClaimMap : EntityTypeConfiguration<IdentityUserClaim>
    {
        public ClaimMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("Claims");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ClaimType).HasColumnName("ClaimType");
            this.Property(t => t.ClaimValue).HasColumnName("ClaimValue");

            // Relationships -CST
            //this.HasRequired(t => t.User)
            //    .WithMany(t => t.Claims)
            //    .Map(d => d.MapKey("User_Id"));

        }
    }
}
