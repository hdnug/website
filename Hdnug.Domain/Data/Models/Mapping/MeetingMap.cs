using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class MeetingMap : EntityTypeConfiguration<Meeting>
    {
        public MeetingMap()
        {
            ToTable("Meeting");
            HasKey(t => t.Id);

            HasMany(t => t.Sponsors)
                .WithOptional(t => t.Meeting);
            HasMany(t => t.Presentations)
                .WithOptional(x => x.Meeting);
        }
    }
}