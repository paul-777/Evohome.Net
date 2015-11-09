using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class ScheduleCapabilities
    {
        [JsonProperty(PropertyName ="maxSwitchpointsPerDay")]
        public int MaxSwitchpointsPerDay
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="minSwitchpointsPerDay")]
        public int MinSwitchpointsPerDay
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="timingResolution")]
        public string TimingResolution
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="setpointValueResolution")]
        public double SetpointValueResolution
        {
            get;
            set;
        }
    }
}