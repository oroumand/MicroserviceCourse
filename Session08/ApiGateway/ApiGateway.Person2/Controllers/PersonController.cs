using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiGateway.Person2.Controllers
{
    [ApiController]

    public class PersonController : ControllerBase
    {
        private static readonly List<Person> people = new List<Person>
            {
                new Person
                {
                    Id =1,
                    FirstName="Alireza2",
                    LastName = "Oroumand"
                },
                                new Person
                {
                    Id =2,
                    FirstName="Farid2",
                    LastName = "Taheri"
                },
                                                new Person
                {
                    Id =3,
                    FirstName="Arash2",
                    LastName = "Azhdari"
                }
            };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public Person Get(int id = 1)
        {
            return people.FirstOrDefault(c => c.Id == id);
        }
    }
}
