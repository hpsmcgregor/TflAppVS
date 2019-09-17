using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using RestSharp;

namespace TflAppVS.Functions.TflApis
{
    public static class LineStatus
    {
        //private readonly string _apiEndPoint = "https://api.tfl.gov.uk/line/mode/tube/status?detail=true";
        private static readonly string _apiEndPoint = "https://api.tfl.gov.uk/line/mode/tube,overground,dlr,tflrail/status";

        public static List<LineStatusDto> GetStatuses()
        {
            var config = new Configuration("./local.settings.json").AppSettings;

            var tflResponse = JsonConvert.DeserializeObject<List<TflDtos.TflLineInfo>>(new ApiHelper(config, _apiEndPoint).GetRequest());

            var lineInfoList = tflResponse.Select(t =>
                new LineStatusDto()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Reason = t.LineStatuses[0].Reason,
                    StatusSeverityDescription = t.LineStatuses[0].StatusSeverityDescription,
                    StatusSeverity = t.LineStatuses[0].StatusSeverity
                }).ToList();

            return lineInfoList;
        }
    }
}
