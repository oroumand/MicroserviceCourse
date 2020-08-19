using Es.EventStore.SqlServer;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session07.Es.CustomerManagement.Infrastructure.Messaging.Send
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Ignore
            };
            string exchangeName = "CustomerManagement";
            var eventRepository = new SqlEventStore();
            DateTime fromDateTime = DateTime.Now.AddDays(-100);
            var factory = new ConnectionFactory() { HostName = "10.100.8.67", Port = 5672, UserName = "admin", Password = "admin" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Fanout);

                do
                {
                    var events = await eventRepository.GetAll(fromDateTime);
                    if (events?.Any() == true)
                        fromDateTime = events.Last().CreatedAt;
                    foreach (var item in events)
                    {
                        var domainEvent = JsonConvert.DeserializeObject(item.Data, _jsonSerializerSettings);
                        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(domainEvent));
                        channel.BasicPublish(exchange: exchangeName,
                                             routingKey: item.Name,
                                             basicProperties: null,
                                             body: body);
                    }
                    System.Threading.Thread.Sleep(1000);
                } while (true);


            }
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0)
                   ? string.Join(" ", args)
                   : "info: Hello World!");
        }
    }
}
