using Microsoft.Extensions.Configuration;
using RandomImageCreator.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RandomImageCreator.App
{
    class Program
    {
        private static IConfigurationRoot _config;
        private static IImageService _imageService;

        private static string _defaultOutPath;
        private static int _imagesToGenerate;
        private static Dictionary<Color, Color> _colourPairs;

        private static void Startup()
        {
            StartConfig();
            StartServices();
            StartVars();
        }

        private static void StartVars()
        {
            _colourPairs = new Dictionary<Color, Color>();
        }

        private static void StartConfig()
        {
            // AppSettings / Config
            var builder = new ConfigurationBuilder()
               .AddJsonFile($"appsettings.json", true, true);

            _config = builder.Build();

            // Set values
            _defaultOutPath = _config["DefaultOutFolder"];
            _imagesToGenerate = int.Parse(_config["ImagesToGenerate"]);
        }

        private static void StartServices()
        {
            string fontName = _config["DefaultFont"];
            string defaultText = _config["DefaultText"];
            int imageSize = int.Parse(_config["DefaultSize"]);

            _imageService = new ImageService(imageSize, defaultText, fontName);
        }

        static void InitColours()
        {
            Console.WriteLine("Generating colour pairs.");
            while (_colourPairs.Count < _imagesToGenerate)
            {
                var (bgColour, fontColour) = ColorGenerator.GenerateColourPair();
                _colourPairs.TryAdd(bgColour, fontColour);
            }
        }

        static void Main(string[] args)
        {
            Startup();

            Console.WriteLine($"Press enter to generate the images.");
            Console.ReadKey();

            InitColours();

            foreach (var item in _colourPairs)
            {
                var outImage = _imageService.CreateEmptyImage(item.Key);
                Console.WriteLine($"Empty image created with background {Domain.Brush.ColorToRGBText(item.Key)}.");

                outImage = _imageService.WriteTextOnImage(item.Value, outImage);
                Console.WriteLine($"Image modified with text {Domain.Brush.ColorToRGBText(item.Value)}");

                IOService.SaveImage(_defaultOutPath, outImage);
                Console.WriteLine("Image saved");
            }
        }
    }
}
