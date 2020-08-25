namespace NetCoreToSap.Controllers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;    
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using NetCoreToSap.Utilities;
    using NetCoreToSap.Models;
    using System.ComponentModel;

    [Route("api/[controller]")]
    [ApiController]
    public class SapController : BaseController
    {
        private readonly IConfiguration _config;

        public SapController(IConfiguration config)
        {
            _config = config;
        }

        // GET api/sap
        [HttpGet]
        public IActionResult Status()
        {
            return Ok(HandleResponse());
        }

        // POST api/sap/login
        [HttpPost("login")]
        public IActionResult SAPLogin()
        {
            try
            {
                /* https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-send-data-using-the-webrequest-class */
                var util = new Utility(_config);
                WebRequest request = WebRequest.Create(util.SAPLoginUrl);
                request.Method = "POST";
                var sapLoginModel = new SapLoginRequest(util.SAPCompanyDB, util.SAPUserName, util.SAPPassword);
                string postData = JsonConvert.SerializeObject(sapLoginModel);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                var responseFromServer = "";
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Console.WriteLine(responseFromServer);
                }

                // Close the response.
                response.Close();
                var data = JsonConvert.DeserializeObject<SapLoginResponse>(responseFromServer);
                return Ok(HandleResponse(data));
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionConstant.CAN_NOT_CONNECT_TO_SAP_LOGIN, ex);
            }
        }

        // GET api/sap/items
        [HttpGet("items")]
        public IActionResult Items()
        {
            try
            {
                var util = new Utility(_config);
                WebRequest request = WebRequest.Create(util.SAPItemsUrl);
                request.Method = "GET";

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                var responseFromServer = "";
                using (var  dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    responseFromServer = reader.ReadToEnd();
                    // Display the content.
                    Console.WriteLine(responseFromServer);
                }

                // Close the response.
                response.Close();
                var data = JsonConvert.DeserializeObject<SapLoginResponse>(responseFromServer);
                return Ok(HandleResponse(data));
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionConstant.CAN_NOT_REQUEST_TO_SAP_ITEMS, ex);
            }
        }
    }
}
