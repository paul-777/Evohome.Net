using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class DHWStatus
    {
        [JsonProperty(PropertyName ="dhwId")]
        public string DhwId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="temperatureStatus")]
        public TemperatureStatus Temperature
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="stateStatus")]
        public StateStatus State
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