using MassTransit;
using Session04.MassTest.Contracts;
using System;
using System.Threading.Tasks;

namespace Session04.MassTest.Client
{
    class Program
    {
        public static async Task Main()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                sbc.Host("rabbitmq://localhost");
            });

            await bus.StartAsync();

            do
            {
                Console.WriteLine("Write your message ");
                var message = new Message
                {
                    Text = Console.ReadLine()
                };
                await bus.Publish(message);
                Console.WriteLine("Continue messaging? y/any thing else: ");
            } while (Console.ReadLine().ToLower() == "y");


            await bus.StopAsync();
        }
    }
}
