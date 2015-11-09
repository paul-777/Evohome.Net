using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class DHWStateCapabilities
    {
        [JsonProperty(PropertyName ="allowedStates")]
        public List<string> AllowedStates
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="allowedModes")]
        public List<string> AllowedModes
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
    }
}