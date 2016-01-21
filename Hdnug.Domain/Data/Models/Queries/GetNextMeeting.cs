using System;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetNextMeeting : Scalar<Meeting>
    {
        public GetNextMeeting()
        {
            ContextQuery = context => context.AsQueryable<Meeting>().FirstOrDefault(m => m.MeetingStartDateTime >= DateTime.Today);
        }
    }
}