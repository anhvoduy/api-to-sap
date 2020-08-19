using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreToSap.Utilities
{
    public class Utility
    {
        public const string inventoryKey = "inventoryKey";

        public const string MyConnectionString = "MyConnectionString";

        public const string DateFormatString = "yyyy-MM-dd";
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