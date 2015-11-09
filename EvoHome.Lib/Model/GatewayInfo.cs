using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class GatewayInfo
    {
        [JsonProperty(PropertyName ="gatewayId")]
        public string GatewayId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="mac")]
        public string Mac
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="crc")]
        public string Crc
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="isWiFi")]
        public bool IsWiFi
        {
            get;
            set;
        }
    }
}