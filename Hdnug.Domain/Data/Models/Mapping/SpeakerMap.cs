using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class SpeakerMap : EntityTypeConfiguration<Speaker>
    {
        public SpeakerMap()
        {
            ToTable("Speaker");
            HasKey(t => t.Id);

            HasOptional(t => t.Photo)
                .WithOptionalDependent()
                .Map(m => m.MapKey("ImageId"));

            HasOptional(t => t.Presentation)
                .WithMany(t => t.Speakers)
                .HasForeignKey(m => m.PresentationId);
        }
    }
}