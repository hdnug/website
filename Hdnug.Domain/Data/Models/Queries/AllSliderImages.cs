using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class AllSliderImages : Query<Image>
    {
        public AllSliderImages()
        {
            ContextQuery = context => context.AsQueryable<Image>().Where(x => x.ImageType == ImageType.Slider);
        }
    }
}