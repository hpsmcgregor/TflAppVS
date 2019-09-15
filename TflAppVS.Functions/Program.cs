using System;

namespace TflAppVS.Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            //var statuses = TflApis.LineStatus.GetStatuses();

            //foreach(var status in statuses)
            //{
            //    Console.WriteLine($"{status.Name}, {status.StatusSeverityDescription}, {status.LineColour.R},{status.LineColour.G},{status.LineColour.B},");
            //}

            var departureBoard = new TflApis.DepartureBoard();
            var arrivals =  departureBoard.GetDepartureBoard();

            foreach(var arrival in arrivals)
            {
                Console.WriteLine($"{arrival.destinationName}, {arrival.expectedArrival}, {arrival.timeToLive}, {arrival.timeToStation}, {arrival.timestamp} {arrival.direction}, {arrival.platformName}");
            }
        }
    }
}
