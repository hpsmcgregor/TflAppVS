using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TflAppVS.Functions.TflApis
{
    public class DepartureBoard
    {
        private string _apiEndPoint;

        public List<TflDtos.Arrivals> GetDepartureBoard()
        {
            var config = new Configuration("./local.settings.json").AppSettings;
            _apiEndPoint = $"https://api.tfl.gov.uk/StopPoint/{config["stationId"]}/Arrivals?mode={config["tflType"]}";

            var tflResponse = JsonConvert.DeserializeObject<List<TflDtos.Arrivals>>(new ApiHelper(config, _apiEndPoint).GetRequest());
            return tflResponse.Where(a => a.destinationNaptanId == config["destinationId"]).OrderBy(x => x.expectedArrival).ToList();
        }
    }
}
