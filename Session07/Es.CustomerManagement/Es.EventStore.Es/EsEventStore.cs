using Es.Framework;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.EventStore.Es
{
    public class EsEventStore : IEventStore
    {
        private readonly IEventStoreConnection _connection;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };
        public EsEventStore(IEventStoreConnection connection) => _connection = connection;
        public async Task<IReadOnlyCollection<IDomainEvent>> LoadAsync(Guid aggregateRootId, string aggregateName)
        {
            string streamName = GetStreamName(aggregateRootId, aggregateName);


            var page = await _connection.ReadStreamEventsForwardAsync(streamName, 0, 1024, false);

            var domainEvents = page.Events.Select(c => TransformEvent(c.Event.Data)).ToList();

            return domainEvents;
        }
        public async Task SaveAsync(Guid aggregateId, string aggregateName, int originatingVersion, IReadOnlyCollection<IDomainEvent> events)
        {
            string streamName = GetStreamName(aggregateId, aggregateName);

            var changes = events
                           .Select(@event =>
                               new EventData(
                                   eventId: Guid.NewGuid(),
                                   type: @event.GetType().Name,
                                   isJson: true,
                                   data: Serialize(@event),
                                   metadata: Serialize(new EventMetadata
                                   { ClrType = @event.GetType().AssemblyQualifiedName ,Version= ++originatingVersion})
                               ))
                           .ToArray();


          await  _connection.AppendToStreamAsync(streamName, ++originatingVersion, changes);
            
        }
        private byte[] Serialize(object data)
            => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data, _jsonSerializerSettings));
        private IDomainEvent TransformEvent(byte[] eventData)
        {
            var jsonData = Encoding.UTF8.GetString(eventData);
            var o = JsonConvert.DeserializeObject(jsonData, _jsonSerializerSettings);
            var evt = o as IDomainEvent;

            return evt;
        }
        private static string GetStreamName(Guid aggregateId, string aggregateName)
        {
            return $"{aggregateName}-{aggregateId.ToString()}";
        }

        public Task<IReadOnlyCollection<EventStoreItem>> GetAll(DateTime? afterDateTime)
        {
            throw new NotImplementedException();
        }

        private class EventMetadata
        {
            public string ClrType { get; set; }
            public int Version { get; set; } 
        }
    }

}
