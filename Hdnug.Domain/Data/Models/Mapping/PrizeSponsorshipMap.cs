using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class PrizeSponsorshipMap : EntityTypeConfiguration<PrizeSponsorship>
    {
        public PrizeSponsorshipMap()
        {
            ToTable("PrizeSponsorship");

            Property(p => p.EndDate).IsOptional();

            HasRequired(t => t.Sponsor)
                .WithMany()
                .HasForeignKey(t => t.SponsorId)
                .WillCascadeOnDelete(false);
        } 
    }
}