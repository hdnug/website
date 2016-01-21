using System;
using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetPrizeSponsorhipById : Scalar<PrizeSponsorship>
    {
        public GetPrizeSponsorhipById(int id)
        {
            ContextQuery = context => context.AsQueryable<PrizeSponsorship>().Include(s => s.Sponsor).Single(s => s.Id == id);
        }
    }
}