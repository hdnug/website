using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetPresentationsByIds : Query<Presentation>
    {
        public GetPresentationsByIds(int[] ids)
        {
            ContextQuery = context => context.AsQueryable<Presentation>().Where(s => ids.Contains(s.Id));
        }
    }
}