using EsSample.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace EsSample.EfStore
{
    public class EfEventStore:IEventStore
    {
        private EventStoreDbContext _eventStoreDbContext = new EventStoreDbContext();


        public void AddEvents(List<IDomainEvent> events,string entityId, string entityType)
        {
            
                foreach (var domainEvent in events)
                {
                _eventStoreDbContext.EventStoreItems.Add(new EventStoreItem
                    {
                        EventDate = DateTime.Now,
                        EventData = JsonConvert.SerializeObject(domainEvent),
                        EventType = domainEvent.GetType().FullName,
                        StreamId = entityId,
                        StreamName = entityType
                    });
                }
            _eventStoreDbContext.SaveChanges();            
        }

        public List<EventStoreItem> Get(string entityId, string entityType)
        {
            return _eventStoreDbContext.EventStoreItems.Where(c => c.StreamName == entityType && c.StreamId == entityId).ToList();
        }
    }
}
