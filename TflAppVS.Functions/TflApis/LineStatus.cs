using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

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
                    Id = t.id,
                    Name = t.name,
                    Reason = t.lineStatuses[0].reason,
                    StatusSeverityDescription = t.lineStatuses[0].statusSeverityDescription,
                    StatusSeverity = t.lineStatuses[0].statusSeverity
                }).ToList();

            return lineInfoList;
        }
    }
}
