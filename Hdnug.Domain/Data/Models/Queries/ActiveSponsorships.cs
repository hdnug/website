using Highway.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class ActivePrizeSponsors : Query<PrizeSponsorship>
    {
        public ActivePrizeSponsors()
        {
            ContextQuery = context => context.AsQueryable<PrizeSponsorship>().Include(x => x.Sponsor).Where(x => x.EndDate > DateTime.Today);
        }
    }
}
