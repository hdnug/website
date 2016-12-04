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

            HasMany(t => t.Presentations)
                .WithMany(t => t.Speakers);
        }
    }
}