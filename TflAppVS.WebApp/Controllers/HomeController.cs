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
        public List<Functions.TflApis.LineStatusDto> FetchedStatuses => Functions.TflApis.GetLineStatus.GetStatuses();

        public List<StatusDto> DisplayStatuses;

        public HomeController()
        {
            DisplayStatuses = new List<StatusDto>();

            foreach(var status in FetchedStatuses)
            {
                var dStatus = new StatusDto();
                dStatus.Id = status.Id;
                dStatus.Name = status.Name;
                dStatus.StatusSeverity = status.StatusSeverity;
                dStatus.StatusSeverityDescription = status.StatusSeverityDescription;
                dStatus.Reason = status.Reason;
                dStatus.LineColour = status.LineColour;
                DisplayStatuses.Add(dStatus);
            }
        }

        public IActionResult Index()
        {
            return View(DisplayStatuses);
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
