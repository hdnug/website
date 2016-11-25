using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class PresentationMap : EntityTypeConfiguration<Presentation>
    {
        public PresentationMap()
        {
            ToTable("Presentation");
            HasKey(t => t.Id);

            HasOptional(x => x.Meeting)
                .WithMany(x => x.Presentations)
                .HasForeignKey(x => x.MeetingId);

            HasMany(t => t.Speakers)
                .WithOptional(t => t.Presentation);
        }
    }
}