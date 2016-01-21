using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class PresentationMap : EntityTypeConfiguration<Presentation>
    {
        public PresentationMap()
        {
            ToTable("Presentation");
            HasKey(t => t.Id);

            HasMany(t => t.Meetings)
                .WithMany(t => t.Presentations);

            HasMany(t => t.Speakers)
                .WithMany(t => t.Presentations);
        }
    }
}