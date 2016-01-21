using System.Collections.Generic;
using System.Web;
using Hdnug.Domain.Data.Models;

namespace Hdnug.Web.Models.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }

        public Image Image { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}