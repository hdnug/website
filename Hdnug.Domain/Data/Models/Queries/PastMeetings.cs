using Highway.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class PastMeetings : Query<Meeting>
    {
        public PastMeetings()
        {
            ContextQuery = context => context.AsQueryable<Meeting>()
                .Include(x => x.Presentations.Select(p => p.Speakers))
                .Include(x => x.Sponsors)
                .Where(x => x.MeetingStartDateTime < DateTime.Today)
                .OrderByDescending(x => x.MeetingStartDateTime);
        }
    }
}
