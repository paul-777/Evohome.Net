using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class GatewayStatus
    {
        [JsonProperty(PropertyName ="gatewayId")]
        public string GatewayId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="temperatureControlSystems")]
        public List<TemperatureControlSystemStatus> TemperatureControlSystems
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="activeFaults")]
        public List<string> ActiveFaults
        {
            get;
            set;
        }
    }
}