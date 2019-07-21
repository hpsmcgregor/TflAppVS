using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System.Configuration;

namespace TflAppVS.Functions.TflApis
{
    public class GetLineStatus
    {
        //private readonly string _apiEndPoint = "https://api.tfl.gov.uk/line/mode/tube/status?detail=true";
        private readonly string _apiEndPoint = "https://api.tfl.gov.uk/line/mode/tube,overground,dlr,tflrail/status";


        public GetLineStatus()
        {
            var config = new Configuration.Configuration("../local.settings.json").AppSettings;
            var client = new RestClient(_apiEndPoint);
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddQueryParameter("app_id", config["app_id"]);
            request.AddQueryParameter("app_key", config["app_key"]);
            var response = (RestResponse)client.Execute(request);
            var content = response.Content;
            //var tflResponse = JsonConvert.DeserializeObject<List<TflLineInfo>>(content);

            //var lineInfoList = tflResponse.Select(t =>
            //    new LineInfo()
            //    {
            //        Id = t.id,
            //        Name = t.name,
            //        Reason = t.lineStatuses[0].reason,
            //        StatusSeverityDescription = t.lineStatuses[0].statusSeverityDescription,
            //        StatusSeverity = t.lineStatuses[0].statusSeverity
            //    }).ToList();

            //return lineInfoList;
        }
    }
}
