using System;
using System.Drawing;

namespace RandomImageCreator.Domain
{
    public class ImageService : IImageService
    {
        public Bitmap CreateEmptyImage(Color backgroundColour, int width, int height)
        {
            throw new NotImplementedException();
        }

        public Bitmap WriteTextOnImage(string text, Color fontColour, string fontName, float fontSize, Bitmap image)
        {
            throw new NotImplementedException();
        }
    }
}
