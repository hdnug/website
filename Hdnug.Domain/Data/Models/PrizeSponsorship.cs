using System;

namespace Hdnug.Domain.Data.Models
{
    public class PrizeSponsorship
    {
        public int Id { get; set; }
        public int SponsorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual  Sponsor Sponsor { get; set; }
    }
}