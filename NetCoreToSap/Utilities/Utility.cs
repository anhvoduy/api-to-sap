using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace NetCoreToSap.Utilities
{
    public class Utility
    {
        private readonly IConfiguration _config;

        public Utility(IConfiguration configuration)
        {
            _config = configuration;
        }

        public const string inventoryKey = "inventoryKey";

        public const string MyConnectionString = "MyConnectionString";

        public const string DateFormatString = "yyyy-MM-dd";

        public string SAPLoginUrl {
            get
            {
                return _config["SAP_LoginUrl"];
            }
        }

        public string SAPItemsUrl
        {
            get
            {
                return _config["SAP_ItemsUrl"];
            }
        }

        public string SAPCompanyDB
        {
            get
            {                
                return _config["SAP_CompanyDB"];
            }
        }

        public string SAPUserName
        {
            get
            {
                return _config["SAP_UserName"];
            }
        }

        public string SAPPassword
        {
            get
            {
                return _config["SAP_Password"];
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
        public const string CAN_NOT_REQUEST_TO_SAP_ITEMS = "CAN_NOT_REQUEST_TO_SAP_ITEMS";
    }
}