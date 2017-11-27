using System;
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

        public static string SaveImageUpload(this HttpPostedFileBase postedImage, IProvideServerMapPath serverMapPathProvider, string uploadDir, string newFileName = null)
        {
            if (newFileName != null)
            {
                //Get the file extension. 
                var fileExtension = Path.GetExtension(postedImage.FileName);
                if (!Path.GetExtension(newFileName).Equals(fileExtension, StringComparison.InvariantCultureIgnoreCase))
                {
                    newFileName += "." + fileExtension;
                }
            }
            var imageFileName = newFileName ?? Path.GetFileName(postedImage.FileName);
            if (imageFileName == null) throw new InvalidOperationException("Cannot save file; no file name found.");
            
            var imageSavePath = Path.Combine(serverMapPathProvider.MapPath(uploadDir), imageFileName);

            if (File.Exists(imageSavePath))
            {
                File.Delete(imageSavePath);
            }
            
            postedImage.SaveAs(imageSavePath);
            return Path.Combine(uploadDir + "/", imageFileName); ;
            
        }

        public static void DeleteImage(this Image imageFile, IProvideServerMapPath serverMapPathProvider, string uploadDir)
        {
            
            var imagePath = Path.Combine(serverMapPathProvider.MapPath(imageFile.ImageUrl));

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }
    }
}