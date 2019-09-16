using System;
namespace TflAppVS.Functions.TflDtos
{
    internal class LineStatus
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public int StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
        public string Reason { get; set; }
        public DateTime Created { get; set; }
        public object[] ValidityPeriods { get; set; }
    }
}
