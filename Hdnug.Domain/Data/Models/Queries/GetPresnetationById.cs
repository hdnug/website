using System.Linq;
using Highway.Data;
using System.Data.Entity;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetPresentationById : Scalar<Presentation>
    {
        public GetPresentationById(int id)
        {
            ContextQuery = context => context.AsQueryable<Presentation>().Include(p => p.Speakers).SingleOrDefault(s => s.Id == id);
        }
    }
}