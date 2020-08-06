using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAP.Middleware.Connector;

namespace NetCoreToSap.Utilities
{
    public class ECCDestinationConfig: IDestinationConfiguration
    {
        public bool ChangeEventsSupported()
        {
            return true;
        }

        public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;

        public RfcConfigParameters GetParameters(string destionationName)
        {
            RfcConfigParameters parms = new RfcConfigParameters();

            //SAP Parameters
            if (destionationName.Equals("mySAPdestination"))
            {
                parms.Add(RfcConfigParameters.AppServerHost, "IPAddress");
                parms.Add(RfcConfigParameters.SystemNumber, "00");
                parms.Add(RfcConfigParameters.SystemID, "ID");
                parms.Add(RfcConfigParameters.User, "Username");
                parms.Add(RfcConfigParameters.Password, "Password");
                parms.Add(RfcConfigParameters.RepositoryPassword, "Password");
                parms.Add(RfcConfigParameters.Client, "100");
                parms.Add(RfcConfigParameters.Language, "EN");
                parms.Add(RfcConfigParameters.PoolSize, "5");
            }

            return parms;
        }
    }
}
