using System;
using Newtonsoft.Json;

namespace TflAppVS.Functions.TflDtos
{
    internal class TflLineInfo
    {
        [JsonProperty("$type")]
        internal string type { get; set; }
        internal string id { get; set; }
        internal string name { get; set; }
        internal string modeName { get; set; }
        internal DateTime created { get; set; }
        internal DateTime modified { get; set; }
        internal LineStatus[] lineStatuses { get; set; }
        internal object[] routeSections { get; set; }
        internal Servicetype[] serviceTypes { get; set; }
    }
}
