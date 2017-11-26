using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hdnug.Domain.Data.Models;

namespace Hdnug.Domain.Extensions
{
    public static class Extensions
    {
        public static string ToEnumDescriptionString<T>(this T val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static Size ScaleImage(this Image sourceImage, Size targetSize)
        {
            var heightRatio =  sourceImage.Height == 0 ? 1 : (double) targetSize.Height / sourceImage.Height ;
            var widthRatio =   sourceImage.Width == 0 ? 1 : (double) targetSize.Width / sourceImage.Width;
            var scalingRatio = heightRatio < widthRatio ? heightRatio : widthRatio; 

            return new Size()
            {
                Height = (int)Math.Round(sourceImage.Height * scalingRatio, 0, MidpointRounding.ToEven),
                Width = (int)Math.Round(sourceImage.Width * scalingRatio, 0, MidpointRounding.ToEven)
            };
            

        }
        public static Size ScaleImage(this Image sourceImage, int height, int width)
        {
            return sourceImage.ScaleImage(new Size(height, width));



        }
    }
}
