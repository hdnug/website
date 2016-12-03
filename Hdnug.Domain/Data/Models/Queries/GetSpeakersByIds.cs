using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetSpeakersByIds : Query<Speaker>
    {
        public GetSpeakersByIds(int[] ids)
        {
            ContextQuery = context => context.AsQueryable<Speaker>().Where(s => ids.Contains(s.Id));
        }
    }
}