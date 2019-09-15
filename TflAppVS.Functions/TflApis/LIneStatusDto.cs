namespace TflAppVS.Functions.TflApis
{
    public class LineStatusDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int StatusSeverity { get; set; }
        public string StatusSeverityDescription { get; set; }
        public string Reason { get; set; }
        public Rgb LineColour
        {
            get
            {
                return ColourHelper.GetRGBColour(Id);
            }
        }
    }
}



