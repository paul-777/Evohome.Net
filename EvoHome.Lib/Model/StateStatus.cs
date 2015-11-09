using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class StateStatus
    {
        [JsonProperty(PropertyName ="state")]
        public string State
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="mode")]
        public string Mode
        {
            get;
            set;
        }
    }
}