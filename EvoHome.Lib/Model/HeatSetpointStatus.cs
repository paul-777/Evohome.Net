using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class HeatSetpointStatus
    {
        [JsonProperty(PropertyName ="targetTemperature")]
        public double TargetTemperature
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="setpointMode")]
        public string SetpointMode
        {
            get;
            set;
        }
    }
}