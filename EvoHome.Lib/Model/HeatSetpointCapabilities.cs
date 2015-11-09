using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class HeatSetpointCapabilities
    {
        [JsonProperty(PropertyName ="maxHeatSetpoint")]
        public double MaxHeatSetpoint
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="minHeatSetpoint")]
        public double MinHeatSetpoint
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="valueResolution")]
        public double ValueResolution
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="allowedSetpointModes")]
        public List<string> AllowedSetpointModes
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