using Newtonsoft.Json;

namespace NetCoreToSap.Models
{
    public class SapLoginModel
    {
        public SapLoginModel()
        {

        }

        public SapLoginModel(string companydb, string username, string password)
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
