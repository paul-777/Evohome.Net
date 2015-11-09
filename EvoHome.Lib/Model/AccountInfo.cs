using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class AccountInfo
    {
        [JsonProperty(PropertyName ="userId")]
        public string UserId
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="username")]
        public string Username
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="firstname")]
        public string Firstname
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="lastname")]
        public string Lastname
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
        [JsonProperty(PropertyName ="postcode")]
        public string Postcode
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
        [JsonProperty(PropertyName ="language")]
        public string Language
        {
            get;
            set;
        }
    }
}