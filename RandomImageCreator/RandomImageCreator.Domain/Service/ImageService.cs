using System;
using System.Drawing;

namespace RandomImageCreator.Domain
{
    public class ImageService : IImageService
    {
        private int ImageSize { get; }
        private string DefaultText { get; }
        private string FontName { get; }
        private int FontSize { get; }

        public ImageService(int imageSize, string defaultText, string fontName)
        {
            ImageSize = imageSize;
            FontSize = (imageSize / 3) * 2;
            DefaultText = defaultText;
            FontName = fontName;
        }

        public Bitmap CreateEmptyImage(Color backgroundColour)
        {
            var newImage = new Bitmap(ImageSize, ImageSize);
            using (Graphics gfx = Graphics.FromImage(newImage))
            {
                var solidBrush = Brush.ColorToBrush(backgroundColour);
                gfx.FillRectangle(solidBrush, 0, 0, ImageSize, ImageSize);
            }

            return newImage;
        }

        public Bitmap WriteTextOnImage(Color fontColour, Bitmap image)
        {
            using (Graphics graphics = Graphics.FromImage(image))
            {
                using (Font font = new Font(FontName, FontSize, FontStyle.Bold))
                {
                    Draw(DefaultText, fontColour, graphics, font);
                }
            }

            return image;
        }

        private void Draw(string text, Color colour, Graphics graphics, Font font)
        {
            var x = (ImageSize / 10);
            graphics.DrawString(text, font, Brush.ColorToBrush(colour), x, 0);
        }
    }
}
