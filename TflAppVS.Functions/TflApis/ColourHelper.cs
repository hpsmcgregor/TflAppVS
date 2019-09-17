using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TflAppVS.Functions.TflApis
{
    public static class ColourHelper
    {
        private static Dictionary<string, Rgb> _tubeColourRGBDictionary = new Dictionary<string, Rgb>();

        static ColourHelper()
        {
            _tubeColourRGBDictionary = new Dictionary<string, Rgb>();

            string coloursJson = File.ReadAllText("./resources/Colours.json");
            var rgbColours = JsonConvert.DeserializeObject<List<RgbColourDto>>(coloursJson);

            foreach (var rgbColour in rgbColours)
            {
                if (!_tubeColourRGBDictionary.ContainsKey(rgbColour.Id))
                {
                    _tubeColourRGBDictionary.Add(rgbColour.Id, rgbColour.Rgb);
                }
            }
        }

        public static Rgb GetRGBColour(string lineId)
        {
            if (!_tubeColourRGBDictionary.ContainsKey(lineId))
            {
                throw new ArgumentException($"Colour for line [{lineId}] could not be found in RGB colour map");
            }

            return _tubeColourRGBDictionary[lineId];
        }
    }
}

