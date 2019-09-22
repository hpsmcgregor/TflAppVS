using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TflAppVS.WebApp.Models;
using TflAppVS.Functions;
using Newtonsoft.Json;
using System;

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
            var config = new Functions.Configuration("./local.settings.json").AppSettings;

            Statuses = new List<StatusDto>();
            Arrivals = new List<ArrivalsDto>();
            TflDto = new TflDto
            {
                StationName = config["stationName"],
                LineColour = JsonConvert.DeserializeObject<Rgb>($"{{\"R\":\"{config["lineColourR"]}\", \"G\":\"{config["lineColourG"]}\", \"B\":\"{config["lineColourB"]}\"}}")
            };

            foreach (var fetchedStatus in FetchedStatuses)
            {
                var status = new StatusDto
                {
                    Id = fetchedStatus.Id,
                    Name = fetchedStatus.Name,
                    StatusSeverity = fetchedStatus.StatusSeverity,
                    StatusSeverityDescription = fetchedStatus.StatusSeverityDescription,
                    Reason = fetchedStatus.Reason,
                    LineColour = fetchedStatus.LineColour,
                    BgColour = new Rgb { R = 255, G = 255, B = 255},
                    TxtColour = new Rgb { R = 0, G = 0, B = 0}
                };
                if (status.StatusSeverity != 10)
                {
                    if (IsSevere(status.StatusSeverity))
                    {
                        status.BgColour = new Rgb { R = 220, G = 36, B = 31 };
                        status.TxtColour = new Rgb { R = 255, G = 255, B = 255 };
                    }
                    else if (IsMinor(status.StatusSeverity))
                    {
                        status.BgColour = new Rgb { R = 255, G = 211, B = 41 };
                        status.TxtColour = new Rgb { R = 255, G = 255, B = 255 };
                    }
                }
                Statuses.Add(status);
            }
            TflDto.Statuses = Statuses;

            foreach(var fetchedArrival in FetchedArrivals)
            {
                var arrival = new ArrivalsDto
                {
                    destinationName = fetchedArrival.destinationName,
                    direction = fetchedArrival.direction,
                    expectedArrival = fetchedArrival.expectedArrival.ToShortTimeString(),
                    lineId = fetchedArrival.lineId,
                    lineName = fetchedArrival.lineName,
                    platformName = fetchedArrival.platformName,
                    stationName = fetchedArrival.stationName,
                    timestamp = fetchedArrival.timestamp.ToShortTimeString(),
                    timeToLive = fetchedArrival.timeToLive.ToShortTimeString(),
                    timeToStation = fetchedArrival.timeToStation
                };
                Arrivals.Add(arrival);
            }

            TflDto.Arrivals = Arrivals;
        }

        private bool IsMinor(int statusSeverity) => statusSeverity == 9 || statusSeverity == 14;

        private bool IsSevere(int statusSeverity) => statusSeverity <= 8 || statusSeverity == 11 || statusSeverity >= 15;

        public IActionResult Index()
        {
            return View(TflDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
