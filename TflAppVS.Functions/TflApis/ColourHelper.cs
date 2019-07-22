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

            string coloursJson = File.ReadAllText("./resources/colours.json");
            var rgbColours = JsonConvert.DeserializeObject<List<RgbColourDto>>(coloursJson);

            //var tubeColours = JArray.Parse(json);
            foreach (var rgbColour in rgbColours)
            {
                if (!_tubeColourRGBDictionary.ContainsKey(rgbColour.Id))
                {
                    _tubeColourRGBDictionary.Add(rgbColour.Id, rgbColour.Rgb);
                }
                //_tubeColorRGBDictionary.Add(tubeColor["id"].Value<string>(), new Rgb(
                //    tubeColor["RGB"]["R"]?.Value<int>() ?? 0,
                //    tubeColor["RGB"]["G"]?.Value<int>() ?? 0,
                //    tubeColor["RGB"]["B"]?.Value<int>() ?? 0));
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

