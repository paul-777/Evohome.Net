using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class DailySchedule
    {
        [JsonProperty(PropertyName ="dayOfWeek")]
        public string DayOfWeek
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="switchpoints")]
        public List<Switchpoint> Switchpoints
        {
            get;
            set;
        }
    }
}