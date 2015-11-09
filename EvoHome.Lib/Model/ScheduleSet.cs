using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evohome.Lib
{
    public class ScheduleSet
    {
        [JsonProperty(PropertyName ="dailySchedules")]
        public List<DailySchedule> DailySchedules
        {
            get;
            set;
        }
    }
}