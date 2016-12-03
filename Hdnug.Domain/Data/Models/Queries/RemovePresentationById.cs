using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class RemovePresentationById : Command
    {
        public RemovePresentationById(int id)
        {
            ContextQuery = context =>
            {
                var presentation = context.AsQueryable<Presentation>().Single(p => p.Id == id);
                context.Remove(presentation);
                context.Commit();
            };
        }
    }
}