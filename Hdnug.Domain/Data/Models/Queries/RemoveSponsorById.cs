using System;
using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class RemoveSponsorById : Command
    {
        public RemoveSponsorById(int id)
        {
            ContextQuery = context =>
            {
                var sponsor = context.AsQueryable<Sponsor>().Single(s => s.Id == id);
                var prizeSponsorships = context.AsQueryable<PrizeSponsorship>().Where(p => p.SponsorId == id);
                foreach (var prizeSponsorship in prizeSponsorships)
                {
                    context.Remove(prizeSponsorship);
                }
                context.Remove(sponsor);
                context.Commit();
            };
        }
    }
}