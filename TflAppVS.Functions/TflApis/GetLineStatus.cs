using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;

namespace TflAppVS.Functions.TflApis
{
    public static class GetLineStatus
    {
        //private readonly string _apiEndPoint = "https://api.tfl.gov.uk/line/mode/tube/status?detail=true";
        private static readonly string _apiEndPoint = "https://api.tfl.gov.uk/line/mode/tube,overground,dlr,tflrail/status";

        public static List<LineStatusDto> GetStatuses()
        {
            var config = new Configuration("./local.settings.json").AppSettings;
            var client = new RestClient(_apiEndPoint);
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddQueryParameter("app_id", config["app_id"]);
            request.AddQueryParameter("app_key", config["app_key"]);
            var response = (RestResponse)client.Execute(request);
            var content = response.Content;
            var tflResponse = JsonConvert.DeserializeObject<List<TflDtos.TflLineInfo>>(content);

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
