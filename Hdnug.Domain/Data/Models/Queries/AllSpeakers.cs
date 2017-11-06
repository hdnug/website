using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class AllSpeakers : Query<Speaker>
    {
        public AllSpeakers()
        {
            ContextQuery = context => context.AsQueryable<Speaker>().Include(s => s.Photo).OrderBy(s => s.LastName);
        }
    }
}