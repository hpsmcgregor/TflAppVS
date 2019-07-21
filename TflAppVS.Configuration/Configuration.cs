using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TflAppVS.Configuration
{
    public class Configuration
    {
        private string _filePath;

        public Configuration(string filePath)
        {
            _filePath = filePath;
        }

        public Dictionary<string, string> AppSettings
        {
            get
            {
                var jsonFile = File.ReadAllText(_filePath);
                var settingsFile = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonFile);
                return settingsFile;
            }
        }
    }
}
