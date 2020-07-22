using System;
using System.Collections.Generic;
using System.Linq;

namespace Session04.TransactionalEvent.Common
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        private readonly List<IDomainEvent> _events;
        protected BaseEntity() => _events = new List<IDomainEvent>();
        public IEnumerable<IDomainEvent> GetEvents() => _events.AsEnumerable();
        public void ClearEvents() => _events.Clear();

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }
    }
}
