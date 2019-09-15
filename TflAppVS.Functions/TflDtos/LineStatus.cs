using System;
namespace TflAppVS.Functions.TflDtos
{
    internal class LineStatus
    {
        internal string type { get; set; }
        internal int id { get; set; }
        internal int statusSeverity { get; set; }
        internal string statusSeverityDescription { get; set; }
        internal string reason { get; set; }
        internal DateTime created { get; set; }
        internal object[] validityPeriods { get; set; }
    }
}
