using System.Collections.Generic;
using RestSharp;

namespace TflAppVS.Functions.TflApis
{
    public class ApiHelper
    {
        private readonly Dictionary<string, string> _config;
        private readonly string _apiEndPoint;

        public ApiHelper(Dictionary<string, string> config, string apiEndPoint)
        {
            _config = config;
            _apiEndPoint = apiEndPoint;
        }

        public string GetRequest()
        {
            var client = new RestClient(_apiEndPoint);
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddQueryParameter("app_id", _config["app_id"]);
            request.AddQueryParameter("app_key", _config["app_key"]);
            var response = (RestResponse)client.Execute(request);
            return response.Content;
        }
    }
}
