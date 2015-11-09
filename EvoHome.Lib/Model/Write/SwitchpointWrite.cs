namespace Evohome.Lib
{
    internal class SwitchpointWrite
    {
        public SwitchpointWrite(Switchpoint a)
        {
            this.TargetTemperature = a.Temperature;
            this.TimeOfDay = a.TimeOfDay;
        }

        public double TargetTemperature
        {
            get;
            set;
        }

        /// <summary>
        /// HH:mm:ss format
        /// </summary>
        public string TimeOfDay
        {
            get;
            set;
        }
    }
}