using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class LocationInfo
    {
        [JsonProperty(PropertyName ="locationId")]
        public string LocationId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="name")]
        public string Name
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="streetAddress")]
        public string StreetAddress
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="city")]
        public string City
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="country")]
        public string Country
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="postcode")]
        public string Postcode
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="locationType")]
        public string LocationType
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="useDaylightSaveSwitching")]
        public bool UseDaylightSaveSwitching
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="timeZone")]
        public TimeZone TimeZone
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="locationOwner")]
        public LocationOwner LocationOwner
        {
            get;
            set;
        }
    }
}