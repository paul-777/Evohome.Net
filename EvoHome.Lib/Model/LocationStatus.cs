using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class LocationStatus
    {
        [JsonProperty(PropertyName ="locationId")]
        public string LocationId
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="gateways")]
        public List<GatewayStatus> Gateways
        {
            get;
            set;
        }
    }
}