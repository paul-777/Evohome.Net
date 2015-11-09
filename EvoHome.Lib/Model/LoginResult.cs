using Newtonsoft.Json;
using System;

namespace Evohome.Lib
{
    public class LoginResult
    {
        [JsonProperty(PropertyName ="access_token")]
        public string Access_token
        {
            get;
            set;
        }
        [JsonProperty(PropertyName ="token_type")]
        public string Token_type
        {
            get;
            set;
        }

        int _expires_in;
        [JsonProperty(PropertyName ="expires_in")]
        public int Expires_in
        {
            get
            {
                return _expires_in;
            }

            set
            {
                _expires_in = value;
                ExpiryUtc = DateTime.UtcNow.AddSeconds(value - 10);
            }
        }

        [JsonIgnore]
        public bool HasExpired
        {
            get
            {
                return DateTime.UtcNow >= ExpiryUtc;
            }
        }

        [JsonIgnore]
        public DateTime ExpiryUtc
        {
            get;
            private set;
        }

        [JsonProperty(PropertyName ="refresh_token")]
        public string Refresh_token
        {
            get;
            set;
        }

        [JsonProperty(PropertyName ="scope")]
        public string Scope
        {
            get;
            set;
        }
    }
}