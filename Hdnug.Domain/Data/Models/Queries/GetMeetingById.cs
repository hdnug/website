using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetMeetingById : Scalar<Meeting>
    {
        public GetMeetingById(int id)
        {
            ContextQuery = context => context.AsQueryable<Meeting>()
                .Include(m=>m.Sponsors)
                .Include(m=>m.Presentations).Include(m=>m.Presentations.Select(p=>p.Speakers))
                .Include(m => m.Location)
                .Single(m=>m.Id == id);
        }
    }
}