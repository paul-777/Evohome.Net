using Newtonsoft.Json;
using System;
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

        /// <summary>
        /// Returns zero if schedule for the required time is not found
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public double GetSetTemperature(DateTime dt)
        {
            foreach (var dy in DailySchedules)
            {
                if ((DayOfWeek)Enum.Parse(typeof(DayOfWeek), dy.DayOfWeek) == dt.DayOfWeek)
                {
                    return dy.GetSetTemperature(dt.TimeOfDay);
                }
            }
            return -1;
        }
    }
}