using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetSponsorsByIds : Query<Sponsor>
    {
        public GetSponsorsByIds(int[] ids)
        {
            ContextQuery = context => context.AsQueryable<Sponsor>().Where(s => ids.Contains(s.Id));
        }
    }
}