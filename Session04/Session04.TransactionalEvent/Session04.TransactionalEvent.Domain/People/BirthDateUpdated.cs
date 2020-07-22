using Session04.TransactionalEvent.Common;
using System;

namespace Session04.TransactionalEvent.Domain.People
{
    public class BirthDateUpdated : IDomainEvent
    {
        public Guid Id { get; set; }
        public DateTime BirthDate{ get; set; }
       
    }
}
