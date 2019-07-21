using System;
using Newtonsoft.Json;

namespace TflAppVS.Functions.TflDtos
{
    internal class TflLineInfo
    {
        [JsonProperty("$type")]
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string modeName { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public LineStatus[] lineStatuses { get; set; }
        public object[] routeSections { get; set; }
        public Servicetype[] serviceTypes { get; set; }
    }
}
