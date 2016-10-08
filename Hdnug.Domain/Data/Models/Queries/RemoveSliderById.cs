using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class RemoveSliderById : Command
    {
        public RemoveSliderById(int id)
        {
            ContextQuery = context =>
            {
                var slider = context.AsQueryable<Image>().Single(x => x.ImageId == id);
                context.Remove(slider);
                context.Commit();
            };
        }
    }
}