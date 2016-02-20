using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class RoleMap : EntityTypeConfiguration<IdentityRole>
    {
        public RoleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Roles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");

        }
    }

    public class UserRoleMap : EntityTypeConfiguration<IdentityUserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRoles");
            this.HasKey(x => new {x.UserId, x.RoleId});
            //cst
            //this.HasRequired(x => x.User).WithMany(x => x.Roles);
            //this.HasRequired(x => x.Role).WithMany();
        }
    }
}
