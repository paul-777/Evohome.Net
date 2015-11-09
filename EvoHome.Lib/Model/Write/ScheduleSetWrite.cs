using System.Collections.Generic;
using System.Linq;

namespace Evohome.Lib
{
    internal class ScheduleSetWrite
    {
        public ScheduleSetWrite(ScheduleSet ss)
        {
            DailySchedules = (
                from a in ss.DailySchedules
                select new DailyScheduleWrite(a)).ToList();
        }

        public List<DailyScheduleWrite> DailySchedules
        {
            get;
            set;
        }
    }
}