namespace NetCoreToSap.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using Newtonsoft.Json;
    using System.Threading.Tasks;

    public class SapLoginResponse
    {
        public SapLoginResponse()
        {

        }

        [JsonProperty("odata.metadata")]
        public string OdataMetadata { get; set; }

        [JsonProperty("SessionId")]
        public string SessionId { get; set; }

        [JsonProperty("Version")]
        public string Version { get; set; }

        [JsonProperty("SessionTimeout")]
        public string SessionTimeout { get; set; }

        [DefaultValue(9999)]
        [JsonProperty("Amount", DefaultValueHandling = DefaultValueHandling.Populate)]
        public decimal Amount { get; set; }
    }
}
