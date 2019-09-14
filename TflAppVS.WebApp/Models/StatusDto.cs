using System;
using TflAppVS.Functions;

namespace TflAppVS.WebApp.Models
{
    public class StatusDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
        public string Reason { get; set; }
        public Rgb LineColour { get; set; }
    }
}
