using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Session04.TransactionalEvent.Dal;
using Session04.TransactionalEvent.Domain.People;

namespace Session04.TransactionalEvent.API.Controllers
{
    [Route("[controller]/[action]")]
    public class PersonController : Controller
    {
        private readonly PersonDB _personDB;

        public PersonController(PersonDB personDB)
        {
            _personDB = personDB;
        }
        public IActionResult All()
        {   
            return Ok(_personDB.People.ToList());
        }
        public IActionResult Create(string firstName="Alireza", string lastName="Oroumand")
        {
            Person person = new Person(Guid.NewGuid(), firstName, lastName);
            _personDB.People.Add(person);
            _personDB.SaveChanges();
            return Ok(person);
        }
    }
}
