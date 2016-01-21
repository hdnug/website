using System;
using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetSponsorById : Scalar<Sponsor>
    {
        public GetSponsorById(int id)
        {
            ContextQuery = context => context.AsQueryable<Sponsor>().Include(s => s.Logo).Single(s => s.Id == id);
        }
    }
}