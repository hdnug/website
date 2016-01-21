using System;
using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class AllPrizeSponsorships : Query<PrizeSponsorship>
    {
        public AllPrizeSponsorships()
        {
            ContextQuery = context => context.AsQueryable<PrizeSponsorship>().Include(s => s.Sponsor).OrderBy(s => s.Sponsor.Name);
        }
    }
}