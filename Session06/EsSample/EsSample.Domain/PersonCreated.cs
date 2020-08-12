using EsSample.Framework;
using System;

namespace EsSample.Domain
{
    public class PersonCreated : IDomainEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
