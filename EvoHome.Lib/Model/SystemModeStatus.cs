using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class SystemModeStatus
    {
        [JsonProperty(PropertyName ="mode")]
        public string Mode
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="isPermanent")]
        public bool IsPermanent
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="timeUntil")]
        public string TimeUntil
        {
            get;
            set;
        }
    }
}