using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Rbt.Toolkits;
using Rbt.Core.Entities;

namespace Comsumer
{
    class Program
    {
        public static ConnectionFactory _connectionFactory;
        public static IConnection _connection;
        public static IModel _model;
        public const string QueueName = "TestQueue";

        public static void Main()
        {
            CreateConnection();


            var consumer = new EventingBasicConsumer(_model);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var payment = body.FromByteArray<Payment>();
                Console.WriteLine($" [x] Received {payment.FirstName} {payment.LastName} {payment.Value}");
            };
            _model.BasicConsume(queue: QueueName,
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

        }
        public static void CreateConnection()
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = "10.100.8.67",
                UserName = "admin",
                Password = "admin",
                Port = Protocols.DefaultProtocol.DefaultPort
            };
            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare(QueueName, true, false, false, null);
        }
    }
}
