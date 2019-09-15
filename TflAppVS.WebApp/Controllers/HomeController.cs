using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TflAppVS.WebApp.Models;
using TflAppVS.Functions;

namespace TflAppVS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public List<Functions.TflApis.LineStatusDto> FetchedStatuses => Functions.TflApis.LineStatus.GetStatuses();
        public List<Functions.TflDtos.Arrivals> FetchedArrivals => new Functions.TflApis.DepartureBoard().GetDepartureBoard();


        public List<StatusDto> Statuses;
        public List<ArrivalsDto> Arrivals;
        public TflDto TflDto;

        public HomeController()
        {
            Statuses = new List<StatusDto>();
            Arrivals = new List<ArrivalsDto>();
            TflDto = new TflDto();

            foreach(var fetchedStatus in FetchedStatuses)
            {
                var status = new StatusDto();
                status.Id = fetchedStatus.Id;
                status.Name = fetchedStatus.Name;
                status.StatusSeverity = fetchedStatus.StatusSeverity;
                status.StatusSeverityDescription = fetchedStatus.StatusSeverityDescription;
                status.Reason = fetchedStatus.Reason;
                status.LineColour = fetchedStatus.LineColour;
                Statuses.Add(status);
            }
            TflDto.Statuses = Statuses;

            foreach(var fetchedArrival in FetchedArrivals)
            {
                var arrival = new ArrivalsDto();
                arrival.destinationName = fetchedArrival.destinationName;
                arrival.direction = fetchedArrival.direction;
                arrival.expectedArrival = fetchedArrival.expectedArrival.ToShortTimeString();
                arrival.lineId = fetchedArrival.lineId;
                arrival.lineName = fetchedArrival.lineName;
                arrival.platformName = fetchedArrival.platformName;
                arrival.stationName = fetchedArrival.stationName;
                arrival.timestamp = fetchedArrival.timestamp.ToShortTimeString();
                arrival.timeToLive = fetchedArrival.timeToLive.ToShortTimeString();
                arrival.timeToStation = fetchedArrival.timeToStation;
                Arrivals.Add(arrival);
            }

            TflDto.Arrivals = Arrivals;
        }

        public IActionResult Index()
        {
            return View(TflDto);
        }


        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
