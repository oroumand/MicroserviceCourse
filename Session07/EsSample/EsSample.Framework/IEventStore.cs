using System.Collections.Generic;
using System.Text;

namespace EsSample.Framework
{
    public interface IEventStore
    {
        void AddEvents(List<IDomainEvent> events, string entityId, string entityType);
        List<EventStoreItem> Get(string entityId, string entityType);

    }
    
}
