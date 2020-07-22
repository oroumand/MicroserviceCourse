using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Session04.MassTest.Contracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session04.MassTest.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IRequestClient<OrderRegistered> requestClient;

        public OrderController(ILogger<OrderController> logger,IRequestClient<OrderRegistered> requestClient)
        {
            _logger = logger;
            this.requestClient = requestClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id=1, string customerNumber="12")
        {
            var (accepted,rejected) = await requestClient.GetResponse<OrderAccepted,OrderRejected>(new OrderRegistered
            {
                CustomerNumber = customerNumber,
                OrderDate = DateTime.Now,
                OrderId = id
            });
            if(accepted.IsCompleted)
                return Ok(await accepted);
            return Ok(await rejected);
        }
    }
}
