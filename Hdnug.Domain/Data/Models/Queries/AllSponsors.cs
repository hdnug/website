using System;
using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class AllSponsors : Query<Sponsor>
    {
        public AllSponsors()
        {
            ContextQuery = context => context.AsQueryable<Sponsor>().Include(s => s.Logo).OrderBy(s => s.Name);
        }
    }
}