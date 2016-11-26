using Highway.Data;
using System;
using System.Data.Entity;
using System.Linq;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class LastTenMeetings : Query<Meeting>
    {
        public LastTenMeetings()
        {
            ContextQuery = context => context.AsQueryable<Meeting>()
                .Include(x => x.Presentations.Select(p => p.Speakers))
                .Include(x => x.Sponsors)
                .Where(x => x.MeetingStartDateTime.Month <= DateTime.Today.Month && x.MeetingStartDateTime.Year <= DateTime.Today.Year)
                .OrderByDescending(x => x.MeetingStartDateTime).Take(10);
        }
    }
}
