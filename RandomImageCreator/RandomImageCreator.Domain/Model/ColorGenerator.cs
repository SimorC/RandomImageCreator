using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RandomImageCreator.Domain
{
    public static class ColorGenerator
    {
        public static (Color, Color) GenerateColourPair()
            => (GenerateRandomColors(), GenerateRandomColors());

        private static Color GenerateRandomColors()
        {
            var rnd = new Random();

            Wait(rnd);
            var r = rnd.Next(0, 255);
            Wait(r);
            var g = rnd.Next(0, 255);
            Wait(g);
            var b = rnd.Next(0, 255);

            return Color.FromArgb(r, g, b);
        }

        // To avoid getting same values from the Random
        private static void Wait(Random rnd)
            => System.Threading.Thread.Sleep(rnd.Next(0, 255));

        private static void Wait(int sleep)
            => System.Threading.Thread.Sleep(sleep);
    }
}
