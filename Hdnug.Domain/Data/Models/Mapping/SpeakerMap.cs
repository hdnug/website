using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class SpeakerMap : EntityTypeConfiguration<Speaker>
    {
        public SpeakerMap()
        {
            ToTable("Speaker");
            HasKey(t => t.Id);
            Property(t => t.FirstName).IsRequired().HasMaxLength(30);
            Property(t => t.LastName).IsRequired().HasMaxLength(50);
            Property(t => t.Phone).IsOptional().HasMaxLength(20);

            Ignore(t => t.Name);
            HasOptional(t => t.Photo)
                .WithOptionalDependent()
                .Map(m => m.MapKey("ImageId"));

            HasMany(t => t.Presentations)
                .WithMany(t => t.Speakers);
        }
    }
}