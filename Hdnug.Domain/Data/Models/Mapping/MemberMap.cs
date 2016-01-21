using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    class MemberMap : EntityTypeConfiguration<Member>
    {
        public MemberMap()
        {
            ToTable("Member");
            HasKey(t => t.Id);
        }
    }
}
