using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Evohome.Lib
{
    public class Zone
    {
        private ScheduleSet _schedule = null;
        [JsonProperty(PropertyName ="zoneId")]
        public string ZoneId
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
        [JsonProperty(PropertyName ="heatSetpointCapabilities")]
        public HeatSetpointCapabilities HeatSetpointCapabilities
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="scheduleCapabilities")]
        public ScheduleCapabilities ScheduleCapabilities
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="name")]
        public string Name
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="zoneType")]
        public string ZoneType
        {
            get;
            set;
        }

        /// <summary>
        /// The current schedule as cached by calling CacheSchedule
        /// </summary>
        [JsonIgnore]
        public ScheduleSet Schedule
        { get
            {
                if (_schedule== null)
                    UpdateSchedule().Wait();
                return _schedule;
            }
            private set { _schedule = value; }
        }

        /// <summary>
        /// Forces repopulation of Schedule property with data from the server
        /// </summary>
        /// <returns></returns>
        public async Task UpdateSchedule()
        {
            this.Schedule = await GetSchedule();
        }

        /// <summary>
        /// Gets the current schedule direct from the servers
        /// </summary>
        /// <returns></returns>
        public async Task<ScheduleSet> GetSchedule()
        {
            return await Controller.MakeGetRequest<ScheduleSet>(string.Format("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/temperatureZone/{0}/schedule", ZoneId));
        }

        /// <summary>
        /// Saves the schedule back to the server
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public async Task SetSchedule(ScheduleSet set)
        {
            await Controller.SendData(string.Format("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/temperatureZone/{0}/schedule", ZoneId), new ScheduleSetWrite(set));
            if (Schedule!= null)
                await UpdateSchedule();
        }

        [JsonIgnore]
        public ZoneStatus Status
        {
            get;
            private set;
        }

        [JsonIgnore]
        public TemperatureControlSystem Parent
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

        internal void UpdateStatus(ZoneStatus zoneStatus)
        {
            Status = zoneStatus;
        }

        public async Task SetTemperatureOverride(int temp, DateTime until)
        {
            TemperatureWrite ts = new TemperatureWrite()
            {HeatSetpointValue = temp};
            ts.TimeUntilDt =until;
            await Controller.SendData(string.Format("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/temperatureZone/{0}/heatSetpoint", ZoneId), ts);
        }

        public async Task CancelTemperatureOverride()
        {
            TemperatureWrite ts = new TemperatureWrite()
            {HeatSetpointValue = 0};
            ts.SetpointMode = TemperatureWrite.Mode.Cancel;
            await Controller.SendData(string.Format("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/temperatureZone/{0}/heatSetpoint", ZoneId), ts);
        }
    }
}