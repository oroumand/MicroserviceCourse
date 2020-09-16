using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public Person Get([FromServices]IPersonCommandRepository repository, Guid id)
        {
            return repository.Get(BusinessId.FromGuid(id));
        }

        [HttpPost]
        public IActionResult Post([FromServices]CreateNewPersonCommandHandler handler, [FromBody]CreateNewPersonCommand command)
        {
            handler.Handle(command);
            return Ok();
        }


    }
}
