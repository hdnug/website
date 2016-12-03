using System;
using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class AllPresentations : Query<Presentation>
    {
        public AllPresentations()
        {
            ContextQuery = context => context.AsQueryable<Presentation>().Include(s => s.Speakers);
        }
    }
}