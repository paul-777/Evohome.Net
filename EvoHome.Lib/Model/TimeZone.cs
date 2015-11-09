using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class TimeZone
    {
        [JsonProperty(PropertyName ="timeZoneId")]
        public string TimeZoneId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="displayName")]
        public string DisplayName
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="offsetMinutes")]
        public int OffsetMinutes
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="currentOffsetMinutes")]
        public int CurrentOffsetMinutes
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="supportsDaylightSaving")]
        public bool SupportsDaylightSaving
        {
            get;
            set;
        }
    }
}