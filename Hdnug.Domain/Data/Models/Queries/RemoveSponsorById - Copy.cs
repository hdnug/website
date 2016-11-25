using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class RemoveSpeakerById : Command
    {
        public RemoveSpeakerById(int id)
        {
            ContextQuery = context =>
            {
                var speaker = context.AsQueryable<Speaker>().Single(s => s.Id == id);
                var presentations = context.AsQueryable<Presentation>().Where(p => p.Speakers.Count < 2 && p.Speakers.Select(s => s.Id).Contains(id));
                foreach (var presentation in presentations)
                {
                    context.Remove(presentation);
                }
                context.Remove(speaker);
                context.Commit();
            };
        }
    }
}