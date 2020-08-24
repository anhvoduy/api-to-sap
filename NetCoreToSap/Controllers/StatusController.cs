namespace NetCoreToSap.Controllers
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;    
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using NetCoreToSap.Utilities;
    using NetCoreToSap.Models;
    using System.ComponentModel;    

    [ApiController]
    [Route("api/[controller]")]    
    public class StatusController : BaseController
    {
        private readonly IConfiguration _config;

        public StatusController(IConfiguration config)
        {
            _config = config;
        }

        // GET api/status
        [HttpGet]
        public IActionResult Status()
        {
            return Ok(HandleResponse());
        }        

        // POST api/status/saplogin
        [HttpPost("saplogin")]
        public IActionResult SAPLogin()
        {            
            try
            {
                /* https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-send-data-using-the-webrequest-class */
                WebRequest request = WebRequest.Create(Utility.SAPLoginUrl);
                request.Method = "POST";
                var sapLoginModel = new SapLoginRequest(Utility.CompanyDB, Utility.UserName, Utility.Password);
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
    }
}