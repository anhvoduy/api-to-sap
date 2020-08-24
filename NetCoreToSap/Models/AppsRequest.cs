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

        public string CompanyDB { get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
