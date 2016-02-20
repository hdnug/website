using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Hdnug.Domain.Data.Models.Mapping
{
    public class LoginMap : EntityTypeConfiguration<IdentityUserLogin>
    {
        public LoginMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey });

            // Properties
            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.LoginProvider)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.ProviderKey)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Logins");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.LoginProvider).HasColumnName("LoginProvider");
            this.Property(t => t.ProviderKey).HasColumnName("ProviderKey");

            // Relationships - CST
            //this.HasRequired(t => t.User)
            //    .WithMany(t => t.Logins)
            //    .HasForeignKey(d => d.UserId);

        }
    }
}
