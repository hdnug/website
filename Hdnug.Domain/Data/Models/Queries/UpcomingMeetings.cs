using Highway.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class UpcomingMeetings : Query<Meeting>
    {
        public UpcomingMeetings()
        {
            ContextQuery = context => context.AsQueryable<Meeting>()
                .Include(x => x.Presentations.Select(p => p.Speakers))
                .Include(x => x.Sponsors)
                .Where(x => x.MeetingStartDateTime > DateTime.Today)
                .OrderBy(x => x.MeetingStartDateTime);
        }
    }
}
