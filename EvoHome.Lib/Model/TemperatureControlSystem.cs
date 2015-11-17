using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evohome.Lib
{
    public class TemperatureControlSystem
    {
        [JsonProperty(PropertyName ="systemId")]
        public string SystemId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="modelType")]
        public string ModelType
        {
            get;
            set;
        }

        List<Zone> _zones;
        [JsonProperty(PropertyName ="zones")]
        public List<Zone> Zones
        {
            get
            {
                return _zones;
            }

            set
            {
                foreach (var z in value)
                    z.Parent = this;
                _zones = value;
            }
        }

        HotWater _dhw;
        [JsonProperty(PropertyName ="dhw")]
        public HotWater DomesticHotWater
        {
            get { return this._dhw; }
            set { value.Parent = this; _dhw = value; }
        }
        [JsonProperty(PropertyName ="")]
        public List<AllowedSystemMode> allowedSystemModes
        {
            get;
            set;
        }

        [JsonIgnore]
        public TemperatureControlSystemStatus Status
        {
            get;
            private set;
        }

        public async Task CacheAllSchedules()
        {
            var tsks = (from z in Zones select z.UpdateSchedule()).ToArray();
            Task.WaitAll(tsks);
        }

        [JsonIgnore]
        public Gateway Parent
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

        internal void UpdateStatus(TemperatureControlSystemStatus status)
        {
            Status = status;
            foreach (var z in Zones)
                z.UpdateStatus((
                    from zs in status.Zones
                    where zs.ZoneId == z.ZoneId
                    select zs).FirstOrDefault());
        }

        public async Task SetSystemModel(StateSet.Mode st, DateTime until)
        {
            StateSet ts = new StateSet()
            {SystemMode = st, TimeUntilDt = until};
            await Controller.SendData(string.Format("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/temperatureControlSystem/{0}/mode", SystemId), ts);
        }

        public class StateSet
        {
            public enum Mode : int
            {
                Normal = 0,
                Custom = 6,
                Eco = 2,
                Away = 3,
                DayOff = 4,
                HeatingOff = 1
            }

            public Mode SystemMode
            {
                get;
                set;
            }

            public string TimeUntil
            {
                get
                {
                    if (TimeUntilDt == DateTime.MaxValue)
                        return null;
                    else
                        return TimeUntilDt.ToString("yyyy-MM-ddTHH:mm:ss");
                }
            }

            public bool Permanent
            {
                get
                {
                    return TimeUntilDt != DateTime.MaxValue;
                }
            }

            [JsonIgnoreAttribute]
            public DateTime TimeUntilDt
            {
                get;
                set;
            }
        }
    }
}