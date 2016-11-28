using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Hdnug.Domain.Data.Models;
using Hdnug.Web.Interfaces;

namespace Hdnug.Web.Inrastructure
{
    public static class Extensions
    {
        public static Dictionary<string, string> ValidateImageUpload(this HttpPostedFileBase postedImage)
        {
            var modelError = new Dictionary<string, string>();

            if (postedImage == null || postedImage.ContentLength == 0)
            {
                modelError.Add("ModelError", "This field is required!");
            }

            else if (!Constants.ValidImageTypes.Contains(postedImage.ContentType))
            {
                modelError.Add("ModelError", "Please choose either a GIF, JPG or PNG image.");
            }

            return modelError;
        }

        public static string SaveImageUpload(this HttpPostedFileBase postedImage, IProvideServerMapPath serverMapPathProvider, string uploadDir)
        {
            var imagePath = Path.Combine(serverMapPathProvider.MapPath(uploadDir), postedImage.FileName);
            var imageUrl = Path.Combine(uploadDir + "/", postedImage.FileName);

            postedImage.SaveAs(imagePath);

            return imageUrl;
        }

        public static void DeleteImage(this Image imageFile, IProvideServerMapPath serverMapPathProvider, string uploadDir)
        {
            var fileName = imageFile.ImageUrl.Substring(imageFile.ImageUrl.LastIndexOf("/", System.StringComparison.Ordinal));
            var imagePath = Path.Combine(serverMapPathProvider.MapPath(uploadDir), Path.GetFileName(fileName.Replace("/", "\\")));

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }
    }
}