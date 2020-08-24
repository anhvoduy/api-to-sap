using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCoreToSap.Utilities
{
    public static class Utility
    {
        public const string inventoryKey = "inventoryKey";

        public const string MyConnectionString = "MyConnectionString";

        public const string DateFormatString = "yyyy-MM-dd";

        public const string SAPLoginUrl = "https://sap-10:50000/b1s/v1/Login";

        public static string CompanyDB
        {
            get
            {
                return "SBODemoAU";
            }
        }

        public static string UserName
        {
            get
            {
                return "manager";
            }
        }

        public static string Password
        {
            get
            {
                return "manager";
            }
        }
    }

    public static class MessageConstant
    {
        public const string COMPLETED = "{0} completed.";
        public const string SUCCSESS = "success";
        public const string CONNECTED = "{0} connected";
        public const string NOTCONNECTED = "{0} not connected";
    }

    public static class ExceptionConstant
    {
        public const string INVALID_REQUEST = "INVALID_REQUEST";
        public const string INVALID_REQUIRED_FIELD_ID = "INVALID_REQUIRED_FIELD_ID";
        public const string CAN_NOT_CONNECT_TO_SAP_LOGIN = "CAN_NOT_CONNECT_TO_SAP_LOGIN";
    }
}