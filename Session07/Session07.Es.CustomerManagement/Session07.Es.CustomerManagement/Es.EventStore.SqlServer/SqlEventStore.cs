using Es.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Es.EventStore.SqlServer
{
    public class SqlEventStore : IEventStore
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };
        private readonly string sqlConnectionString;
        public SqlEventStore(IConfiguration  configuration)
        {
            sqlConnectionString = configuration.GetConnectionString("EventStoreDb");
        }
        public SqlEventStore()
        {
            sqlConnectionString = "Server = 10.100.8.174; Database=EventSourcing;User Id =sa;Password=1qaz!QAZ; MultipleActiveResultSets=true";
        }
        public async Task<IReadOnlyCollection<IDomainEvent>> LoadAsync(Guid aggregateRootId, string aggregateName)
        {
            if (aggregateRootId == null) throw new InvalidOperationException("AggregateRootId cannot be null");
            if (string.IsNullOrWhiteSpace(aggregateName)) throw new InvalidOperationException("AggregateName cannot be null");

            var query =$"SELECT * FROM EventStore WHERE [AggregateId] = @AggregateId and [Aggregate] = @Aggregate ORDER BY [Version] ASC";

            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                var events =  (await sqlConnection.QueryAsync<EventStoreItem>(query.ToString(), new { AggregateId=aggregateRootId, Aggregate =aggregateName})).ToList();
                var domainEvents = events.Select(TransformEvent).Where(x => x != null).ToList().AsReadOnly();
                return domainEvents;
            }
        }
        private IDomainEvent TransformEvent(EventStoreItem eventSelected)
        {
            var o = JsonConvert.DeserializeObject(eventSelected.Data, _jsonSerializerSettings);
            var evt = o as IDomainEvent;

            return evt;
        }

        public async Task SaveAsync(Guid aggregateId, string aggregateName, int originatingVersion, IReadOnlyCollection<IDomainEvent> events)
        {
            if (events.Count < 1)
                return;
            
            var createdAt = DateTime.Now;
          
            string query = $"INSERT INTO EventStore(Id, CreatedAt, Version, Name, AggregateId, Data, Aggregate)" +
                $"VALUES (@Id,@CreatedAt,@Version,@Name,@AggregateId,@Data,@Aggregate)";
            
            var listOfEvents = events.Select(ev => new
            {
                Aggregate = aggregateName,
                CreatedAt = createdAt,
                Data = JsonConvert.SerializeObject(ev, Formatting.Indented, _jsonSerializerSettings),
                Id = Guid.NewGuid(),
                ev.GetType().Name,
                AggregateId = aggregateId.ToString(),
                Version = ++originatingVersion
            });
            
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync(query, listOfEvents);
            }
        }

        public async Task<IReadOnlyCollection<EventStoreItem>> GetAll(DateTime? afterDateTime)
        {
            string where = afterDateTime.HasValue ? $"WHERE CreatedAt >  '{afterDateTime}' " : "";
            var query = $"SELECT * FROM EventStore {where} ORDER BY CreatedAt,[Version] ASC";

            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                var events = (await sqlConnection.QueryAsync<EventStoreItem>(query.ToString())).ToList();
              
                return events;
            }
        }
    }
}
