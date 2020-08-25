using Newtonsoft.Json;

namespace NetCoreToSap.Models
{
    public class SapLoginRequest
    {
        public SapLoginRequest()
        {

        }

        public SapLoginRequest(string companydb, string username, string password)
        {
            CompanyDB = companydb;
            UserName = username;
            Password = password;
        }

        [JsonProperty("CompanyDB")]
        public string CompanyDB { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
