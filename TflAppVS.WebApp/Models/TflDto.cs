using System.Collections.Generic;

namespace TflAppVS.WebApp.Models
{
    public class TflDto
    {
        public List<StatusDto> Statuses;
        public List<ArrivalsDto> Arrivals;
        public string StationName;
        public Functions.Rgb LineColour;
    }
}
