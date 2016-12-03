using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class RemoveMeetingById : Command
    {
        public RemoveMeetingById(int id)
        {
            ContextQuery = context =>
            {
                var meeting = context.AsQueryable<Meeting>().Single(p => p.Id == id);
                context.Remove(meeting);
                context.Commit();
            };
        }
    }
}