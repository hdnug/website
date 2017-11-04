using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class MeetingMap : EntityTypeConfiguration<Meeting>
    {
        public MeetingMap()
        {
            ToTable("Meeting");
            HasKey(t => t.Id);

            HasRequired(e => e.Location).WithMany().HasForeignKey(e => e.LocationId);

            HasMany(t => t.Sponsors)
                .WithMany(t => t.Meetings);
            HasMany(t => t.Presentations)
                .WithMany(x => x.Meetings);
        }
    }
}