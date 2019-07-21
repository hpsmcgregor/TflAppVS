using System.Collections.Generic;
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
                var settingsFile = JsonConvert.DeserializeObject<Dictionary<string, string>>(_filePath);
                return settingsFile;
            }
        }
    }
}
