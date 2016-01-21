using System;
using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class RemovePrizeSponsorshipById : Command
    {
        public RemovePrizeSponsorshipById(int id)
        {
            ContextQuery = context =>
            {
                var prizeSponsorship = context.AsQueryable<PrizeSponsorship>().Single(p => p.Id == id);
                context.Remove(prizeSponsorship);
                context.Commit();
            };
        }
    }
}