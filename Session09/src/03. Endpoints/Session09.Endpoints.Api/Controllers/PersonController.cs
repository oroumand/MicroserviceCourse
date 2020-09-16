using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Session09.Core.ApplicationServices.People.CommandHandlers;
using Session09.Core.ApplicationServices.People.Commands;
using Session09.Core.Domain.People.Entities;
using Session09.Core.Domain.People.Repositories;
using Zamin.Core.Domain.TacticalPatterns;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Session09.Endpoints.Api.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }
        public IActionResult Get([FromServices]IPersonCommandRepository repository, [FromQuery] Guid id)
        {
            _logger.LogInformation("Hi");
            Person person =  repository.Get(BusinessId.FromGuid(id));
            return Ok(new
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Id = person.Id.Value

            });
        }

        [HttpPost]
        public IActionResult Post([FromServices]CreateNewPersonCommandHandler handler, [FromBody]CreateNewPersonCommand command)
        {
            handler.Handle(command);
            return Ok();
        }


    }
}
