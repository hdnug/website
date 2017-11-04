using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hdnug.Domain.Data.Models;
using Highway.Data;

namespace Hdnug.Domain.Data.Queries
{
    public class MeetingList : Query<Meeting>
    {
        public MeetingList()
        {
            ContextQuery = context => context.AsQueryable<Meeting>()
                .Include(e => e.Location);
        }
    }
}
