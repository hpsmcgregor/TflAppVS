using System;
using Newtonsoft.Json;

namespace TflAppVS.Functions.TflDtos
{
    internal class TflLineInfo
    {
        [JsonProperty("$type")]
        public string Type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ModeName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public LineStatus[] LineStatuses { get; set; }
        public object[] RouteSections { get; set; }
        public Servicetype[] ServiceTypes { get; set; }
    }
}
