using System;
namespace TflAppVS.Functions.TflDtos
{
    internal class LineStatus
    {
        public string type { get; set; }
        public int id { get; set; }
        public int statusSeverity { get; set; }
        public string statusSeverityDescription { get; set; }
        public string reason { get; set; }
        public DateTime created { get; set; }
        public object[] validityPeriods { get; set; }
    }
}
