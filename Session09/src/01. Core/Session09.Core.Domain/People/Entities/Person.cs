using Session09.Core.Domain.People.Events;
using Session09.Core.Domain.People.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zamin.Core.Domain.TacticalPatterns;

namespace Session09.Core.Domain.People.Entities
{
    public class Person : AggregateRoot
    {
        public int PersonId { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }


        private Person() { }

        public static Person Create(BusinessId id, string firstName, string lastName)
        {
            if (id == null)
            {
                throw new InvalidPersonIdException("PersonIdIsNull");
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new InvalidFirstNameException("FirstNameIsNull");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new InvalidLastNameException("LastNameIsNull");

            }


            var person = new Person
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
            person.AddDomainEvent(new PersonCreated(person.Id.Value, person.FirstName, person.LastName));
            return person;
        }

    }
}
