using System;

namespace Hdnug.Domain.Data.Models
{
    // TODO: Refactor model. PrizeSponsorship "has a" Sponsor.
    // The current relationship is not necessarialy wrong but 
    // should probably be modeled as generalized hierarchy instead
    // where a Sponsor "is a" PrizeSponsor.
    public class PrizeSponsorship
    {
        public int Id { get; set; }
        public int SponsorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual  Sponsor Sponsor { get; set; }
    }
}