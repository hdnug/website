using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<IdentityUser>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");

            //cst
            //this.HasMany(x => x.Roles).WithRequired(x => x.User);
        }
    }
}
