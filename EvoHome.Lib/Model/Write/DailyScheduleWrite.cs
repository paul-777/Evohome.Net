using System;
using System.Collections.Generic;
using System.Linq;

namespace Evohome.Lib
{
    internal class DailyScheduleWrite
    {
        public DailyScheduleWrite(DailySchedule s)
        {
            Day d;
            if (Enum.TryParse(s.DayOfWeek, out d))
                DayOfWeek = d;
            this.Switchpoints = (
                from a in s.Switchpoints
                select new SwitchpointWrite(a)).ToList();
        }

        public enum Day : int
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6,
        }

        public Day DayOfWeek
        {
            get;
            set;
        }

        public List<SwitchpointWrite> Switchpoints
        {
            get;
            set;
        }
    }
}