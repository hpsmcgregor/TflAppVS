using System;

namespace TflAppVS.Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            var statuses = TflApis.GetLineStatus.GetStatuses();

            foreach(var status in statuses)
            {
                Console.WriteLine($"{status.Name}, {status.StatusSeverityDescription}, {status.LineColour.R},{status.LineColour.G},{status.LineColour.B},");
            }
        }
    }
}
