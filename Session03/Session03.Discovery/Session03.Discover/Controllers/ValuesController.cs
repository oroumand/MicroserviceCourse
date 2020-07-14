using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Steeltoe.Common.Discovery;
using System.Net.Http;

namespace Session03.Discover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;
        DiscoveryHttpClientHandler _handler;
        public ValuesController(ILogger<ValuesController> logger, IDiscoveryClient client)
        {
            _logger = logger;
            _handler = new DiscoveryHttpClientHandler(client);
        }

        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient(_handler, false);
            var result =  await client.GetStringAsync("http://Eureka_Register_Example/api/values");
            return result;
        }
    }
}
