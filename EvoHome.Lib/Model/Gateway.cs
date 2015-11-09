using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Evohome.Lib
{
    public class Gateway
    {
        [JsonProperty(PropertyName ="gatewayInfo")]
        public GatewayInfo GatewayInfo
        {
            get;
            set;
        }

        [JsonIgnore]
        public Location Parent
        {
            get;
            internal set;
        }

        [JsonIgnore]
        public Controller Controller
        {
            get
            {
                return this.Parent?.Controller;
            }
        }

        List<TemperatureControlSystem> _temperatureControlSystems;
        [JsonProperty(PropertyName ="temperatureControlSystems")]
        public List<TemperatureControlSystem> TemperatureControlSystems
        {
            get
            {
                return _temperatureControlSystems;
            }

            set
            {
                foreach (var tc in value)
                    tc.Parent = this;
                _temperatureControlSystems = value;
            }
        }

        internal void UpdateStatus(GatewayStatus status)
        {
            foreach (var t in TemperatureControlSystems)
                t.UpdateStatus((
                    from ts in status.TemperatureControlSystems
                    where ts.SystemId == t.SystemId
                    select ts).FirstOrDefault());
        }
    }
}