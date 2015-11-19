using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class ZoneStatus
    {
        [JsonProperty(PropertyName ="zoneId")]
        public string ZoneId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="temperatureStatus")]
        public TemperatureStatus TemperatureStatus
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="activeFaults")]
        public List<ActiveFault> ActiveFaults
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="heatSetpointStatus")]
        public HeatSetpointStatus HeatSetpointStatus
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="name")]
        public string Name
        {
            get;
            set;
        }
    }
}