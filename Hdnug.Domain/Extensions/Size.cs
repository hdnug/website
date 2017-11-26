namespace Hdnug.Domain.Extensions
{
    public struct Size
    {

        public Size(int heightWidth)
        {
            Height = heightWidth;
            Width = heightWidth;
        }

        public Size(int height, int width)
        {
            Height = height;
            Width = width;
        }
        public int Height;
        public int Width; 
    }
}