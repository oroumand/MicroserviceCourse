using System;
using System.Collections.Generic;
using System.Text;
using Zamin.Core.Domain.TacticalPatterns;

namespace Session09.Core.Domain.People.Events
{
    public class PersonCreated:IDomainEvent
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Id { get;}

        public PersonCreated(Guid id,string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id.ToString();

        }
    }
}
