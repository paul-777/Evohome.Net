using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class TemperatureStatus
    {
        [JsonProperty(PropertyName ="temperature")]
        public double Temperature
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="isAvailable")]
        public bool IsAvailable
        {
            get;
            set;
        }
    }
}