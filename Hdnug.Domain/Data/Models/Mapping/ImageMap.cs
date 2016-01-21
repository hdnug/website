using System.Data.Entity.ModelConfiguration;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            ToTable("Image");
            HasKey(t => t.ImageId);
        } 
    }
}