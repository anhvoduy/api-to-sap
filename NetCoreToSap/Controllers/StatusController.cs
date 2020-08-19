namespace NetCoreToSap.Controllers
{
    using System;    
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;    

    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController
    {
        private readonly IConfiguration _config;

        public StatusController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Status()
        {
            return Ok(HandleResponse());
        }

        [HttpPost]
        public IActionResult SAPLogin()
        {
            return Ok(HandleResponse());
        }
    }
}