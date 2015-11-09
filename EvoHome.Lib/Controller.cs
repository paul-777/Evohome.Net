using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Evohome.Lib
{


    // http://json2csharp.com/#
    // http://jsonclassgenerator.codeplex.com/

    public class Controller
    {

        SemaphoreSlim sem = new SemaphoreSlim(1);
        private LoginResult LoginData
        {
            get;
            set;
        }
        public List<Location> Locations
        {
            get;
            private set;
        } = new List<Location>();
        private string Password
        {
            get;
            set;
        }
        private string User
        {
            get;
            set;
        }

        public AccountInfo AccountInfo
        { get; set; }

        public Dictionary<string, object> InstallationInfo
        { get; set; }

        public async Task Init(string user, string password)
        {
            this.User = user;
            this.Password = password;
            Locations.Clear();
            await Login();
            await UserAccount();
            await RefreshSetup();
            await UpdateStatus();
        }


        public async Task Login()
        {
            string url = "https://rs.alarmnet.com:443/TotalConnectComfort/Auth/OAuth/Token";
            using (var client = new HttpClient())
            {
                var data = new Dictionary<string, string>
                {
                    {"Content-Type",    "application/x-www-form-urlencoded; charset=utf-8"},
                    {"Host",   "rs.alarmnet.com/"},
                    {"Cache-Control","no-store no-cache"},
                    {"Pragma", "no-cache"},
                    {"grant_type", "password"},
                    {"scope",  "EMEA-V1-Basic EMEA-V1-Anonymous EMEA-V1-Get-Current-User-Account"},
                    {"Username",   User},
                    {"Password",   Password},
                    {"Connection", "Keep-Alive"}
                };

                var content = new FormUrlEncodedContent(data);

                client.DefaultRequestHeaders.Add("Authorization", "Basic YjAxM2FhMjYtOTcyNC00ZGJkLTg4OTctMDQ4YjlhYWRhMjQ5OnRlc3Q=");
                client.DefaultRequestHeaders.Add("Accept", "application/json, application/xml, text/json, text/x-json, text/javascript, text/xml");
                var response = await client.PostAsync(url, content);

                var responseString = await response.Content.ReadAsStringAsync();
                LoginData = JsonConvert.DeserializeObject<LoginResult>(responseString);
            }
        }

        

        public async Task UpdateStatus()
        {
            foreach (var loc in Locations)
                await loc.UpdateStatus();
        }

        private async Task UserAccount()
        {
            AccountInfo = await MakeGetRequest<AccountInfo>("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/userAccount");
        }

        public async Task RefreshSetup()
        {
            var info = await MakeGetRequest<Location[]>(string.Format("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/location/installationInfo?userId={0}&includeTemperatureControlSystems=True", AccountInfo.UserId));
            foreach (var loc in info)
                loc.Controller = this;
            Locations.Clear();
            Locations.AddRange(info);
            await UpdateStatus();
        }
        /*
        public async Task<object> FullInstallation(InstallationModel.LocationInfo location)
        {
            return await MakeGetRequest<InstallationModel.Location>(string.Format("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/location/{0}/installationInfo?includeTemperatureControlSystems=True", location.locationId));
        }*/



        /*
        private async Task<object> Gateway()
        {
            return await MakeGetRequest<Dictionary<string, object>>("https://rs.alarmnet.com:443/TotalConnectComfort/WebAPI/emea/api/v1/gateway");
        }
        */


        public async Task<T> MakeGetRequest<T>(string reqUrl)
        {
            await sem.WaitAsync();
            try
            {
                if (LoginData.HasExpired)
                    await Login();
            }
            finally
            {
                sem.Release();
            }
            string responseString;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + LoginData.Access_token);
                client.DefaultRequestHeaders.Add("applicationId", "b013aa26-9724-4dbd-8897-048b9aada249");
                client.DefaultRequestHeaders.Add("Accept", "application/json, application/xml, text/json, text/x-json, text/javascript, text/xml");

                responseString = await client.GetStringAsync(reqUrl);
            }
            return JsonConvert.DeserializeObject<T>(responseString);
        }


        public async Task SendData<T>(string url, T data)
        {
            string json = JsonConvert.SerializeObject(data);

            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, url);
                req.Content = new StringContent(json); //, Encoding.UTF8, "application/json");
                req.Content.Headers.Remove("Content-Type");
                req.Content.Headers.Add("Content-Type", "application/json");
                
                req.Headers.Add("Authorization", "bearer " + LoginData.Access_token);
                req.Headers.Add("applicationId", "b013aa26-9724-4dbd-8897-048b9aada249");
                req.Headers.Add("Accept", "application/json, application/xml, text/json, text/x-json, text/javascript, text/xml");
                //req.Headers.Add("Content-Type", "application/json");
                              

                var x = await client.SendAsync(req);

                x.EnsureSuccessStatusCode();
            }
        }

    }
}

