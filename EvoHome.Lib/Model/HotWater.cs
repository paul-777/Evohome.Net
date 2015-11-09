using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Evohome.Lib
{
    public class HotWater
    {
        [JsonProperty(PropertyName ="dhwId")]
        public string DhwId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="dhwStateCapabilitiesResponse")]
        public DHWStateCapabilities StateCapabilities
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="scheduleCapabilitiesResponse")]
        public ScheduleCapabilities ScheduleCapabilities
        {
            get;
            set;
        }
        

        [JsonIgnore]
        public Controller Controller
        {
            get
            {
                return this.Parent?.Controller;
            }
        }
        [JsonIgnore]
        public TemperatureControlSystem Parent
        {
            get;
            internal set;
        }

        public enum Mode : int
        {
            On = 1,
            Off = 2,
            Auto = 0
        }

        class DhwSet
        {
            public Mode Mode
            { get; set; }

            public int State
            {
                get; set;
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

            [JsonIgnoreAttribute]
            public DateTime TimeUntilDt
            {
                get; set;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="until">Use DateTime.MaxValue for always</param>
        /// <returns></returns>
        public async Task SetMode(Mode mode, DateTime until)
        {
            DhwSet d = new DhwSet() { Mode = mode, TimeUntilDt = until, State=(mode==Mode.On ? 1 : 0) };
            await Controller.SendData(string.Format("https://rs.alarmnet.com/TotalConnectComfort/WebAPI/emea/api/v1/domesticHotWater/{0}/state", DhwId), d);
        }

    }
}