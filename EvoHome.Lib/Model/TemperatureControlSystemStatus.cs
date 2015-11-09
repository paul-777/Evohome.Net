using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class TemperatureControlSystemStatus
    {
        [JsonProperty(PropertyName ="systemId")]
        public string SystemId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="zones")]
        public List<ZoneStatus> Zones
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
        [JsonProperty(PropertyName ="systemModeStatus")]
        public SystemModeStatus SystemModeStatus
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="dhw")]
        public DHWStatus DomesticHotWater
        {
            get;
            set;
        }
    }
}