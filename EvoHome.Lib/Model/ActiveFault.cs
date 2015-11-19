using Newtonsoft.Json;
using System;

namespace Evohome.Lib
{
    public class ActiveFault
    {
        [JsonProperty(PropertyName = "faultType")]
        public string FaultType
        { get; set; }

        [JsonProperty(PropertyName = "since")]
        public string Since
        { get; set; }

        [JsonIgnore]
        public DateTime SinceAsDateTime
        {
            get { return DateTime.ParseExact(Since, "yyyy-MM-ddTHH:mm:ss.fff", null); }
        }
        
    }
}
