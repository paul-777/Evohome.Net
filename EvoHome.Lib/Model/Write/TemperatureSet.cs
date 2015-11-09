using Newtonsoft.Json;
using System;

namespace Evohome.Lib
{
    internal class TemperatureWrite
    {
        public enum Mode : int
        {
            Continuous = 1,
            Until = 2,
            Cancel = 0
        }

        public int HeatSetpointValue
        {
            get;
            set;
        }

        Mode setpointMode;

        public Mode SetpointMode
        {
            get { return TimeUntilDt==DateTime.MaxValue ? Mode.Continuous : setpointMode; }
            set { setpointMode = value; }
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
}



