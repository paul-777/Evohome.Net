using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class AllowedSystemMode
    {
        [JsonProperty(PropertyName ="systemMode")]
        public string SystemMode
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="canBePermanent")]
        public bool CanBePermanent
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="canBeTemporary")]
        public bool CanBeTemporary
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="maxDuration")]
        public string MaxDuration
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
        [JsonProperty(PropertyName ="timingMode")]
        public string TimingMode
        {
            get;
            set;
        }
    }
}