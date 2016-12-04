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
                .WithMany(t => t.Meetings);
            HasMany(t => t.Presentations)
                .WithMany(x => x.Meetings);
        }
    }
}