using Newtonsoft.Json;

namespace Evohome.Lib
{
    public class LocationOwner
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
    }
}