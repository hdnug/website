using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class SponsorMap : EntityTypeConfiguration<Sponsor>
    {
        public SponsorMap()
        {
            ToTable("Sponsor");
            HasKey(t => t.Id);


            HasOptional(t => t.Meeting)
                .WithMany(t => t.Sponsors)
                .HasForeignKey(x => x.MeetingId);

            HasOptional(t => t.Logo)
                .WithOptionalDependent()
                .Map(m => m.MapKey("ImageId"))
                .WillCascadeOnDelete(true);
        }
    }
}