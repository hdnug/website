using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetMeetingDetailsById : Scalar<Meeting>
    {
        public GetMeetingDetailsById(int id)
        {
            ContextQuery = context => context.AsQueryable<Meeting>()
                .Include(m=>m.Sponsors)
                .Include(m=>m.Presentations).Include(m=>m.Presentations.Select(p=>p.Speakers))
                .Single(m=>m.Id == id);
        }
    }
}