using System.Drawing;

namespace RandomImageCreator.Domain
{
    public interface IImageService
    {
        public Bitmap CreateEmptyImage(Color backgroundColour, int width, int height);
        public Bitmap WriteTextOnImage(string text, Color fontColour, string fontName, float fontSize, Bitmap image);
    }
}
