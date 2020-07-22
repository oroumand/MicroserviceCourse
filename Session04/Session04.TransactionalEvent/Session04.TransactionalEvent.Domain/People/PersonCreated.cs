using Session04.TransactionalEvent.Common;
using System;

namespace Session04.TransactionalEvent.Domain.People
{
    public class PersonCreated:IDomainEvent
    {
        public Guid Id { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
    }
}
