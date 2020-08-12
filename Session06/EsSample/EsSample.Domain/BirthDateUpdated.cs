using EsSample.Framework;
using System;

namespace EsSample.Domain
{
    public class BirthDateUpdated : IDomainEvent
    {
        public Guid Id { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
