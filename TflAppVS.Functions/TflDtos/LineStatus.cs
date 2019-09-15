using System;
namespace TflAppVS.Functions.TflDtos
{
    internal class LineStatus
    {
        internal string Type { get; set; }
        internal int Id { get; set; }
        internal int StatusSeverity { get; set; }
        internal string StatusSeverityDescription { get; set; }
        internal string Reason { get; set; }
        internal DateTime Created { get; set; }
        internal object[] ValidityPeriods { get; set; }
    }
}
