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
    }
}
