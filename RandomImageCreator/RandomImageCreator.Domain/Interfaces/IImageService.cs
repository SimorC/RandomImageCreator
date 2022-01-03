using System.Drawing;

namespace RandomImageCreator.Domain
{
    public interface IImageService
    {
        public Bitmap CreateEmptyImage(Color backgroundColour);
        public Bitmap WriteTextOnImage(Color fontColour, Bitmap image);
    }
}
