using Highway.Data;
using System;

namespace Hdnug.Domain.Data.Models
{
    public class Image : IIdentifiable<int>
    {
        public Image()
        {
        }

        public Image(Image image)
        {
            Id = image.Id;
            Title = image.Title;
            AltText = image.AltText;
            Caption = image.Caption;
            ImageUrl = image.ImageUrl;
            ImageType = image.ImageType;
            Height = image.Height;
            Width = image.Width; 
            CreatedDate = image.CreatedDate;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string AltText { get; set; }

        public string Caption { get; set; }

        public string ImageUrl { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public ImageType ImageType { get; set; }

        private DateTime? _createdDate;

        public DateTime CreatedDate
        {
            get { return _createdDate ?? DateTime.UtcNow; }
            set { _createdDate = value; }
        }
    }
}