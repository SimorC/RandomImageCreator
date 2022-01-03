using System.Drawing;

namespace RandomImageCreator.Domain
{
    public class Brush
    {
        public static SolidBrush HexToBrush(string hex)
        {
            var color = ColorTranslator.FromHtml(hex);
            return new SolidBrush(color);
        }

        public static SolidBrush ColorToBrush(Color colour)
            => new SolidBrush(colour);

        public static string ColorToRGBText(Color colour)
            => $"({colour.R}, {colour.G}, {colour.B})";
    }
}