namespace NetCoreToSap.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NetCoreToSap.Utilities;

    [ApiController]
    public class BaseController : ControllerBase
    {
        public static object HandleResponse(object data = null, HttpStatusCode code = HttpStatusCode.OK, string message = MessageConstant.SUCCSESS)
        {
            if (data == null)
            {
                return new { Code = (int)code, Message = message };
            }
            return new { Code = code, Message = message, Data = data, };
        }

        public static string Message(string message, params object[] arg)
        {
            if (arg.Length == 0)
            {
                return message;
            }
            return String.Format(message, arg);
        }
    }
}