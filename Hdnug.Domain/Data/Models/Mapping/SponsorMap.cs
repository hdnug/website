using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class SponsorMap : EntityTypeConfiguration<Sponsor>
    {
        public SponsorMap()
        {
            ToTable("Sponsor");
            HasKey(t => t.Id);


            HasMany(t => t.Meetings)
                .WithMany(t => t.Sponsors);

            HasOptional(t => t.Logo)
                .WithOptionalDependent()
                .Map(m => m.MapKey("ImageId"))
                .WillCascadeOnDelete(true);
        }
    }
}