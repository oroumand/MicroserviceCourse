using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Session04.MassTest.Contracts;
namespace Session04.MassTest.Components.Consumers
{
    public class OrderRegisteredHandler : IConsumer<OrderRegistered>
    {
        public async Task Consume(ConsumeContext<OrderRegistered> context)
        {
            System.Threading.Thread.Sleep(10);
            if (context.Message.OrderId == 2)
            {
                await context.RespondAsync<OrderRejected>(new OrderRejected
                {
                    RejectBy = "Alireza Oroumand rejector",
                    Reason = "nothing else matter",
                    RejectDate = DateTime.Now,
                    OrderId = context.Message.OrderId

                }); ;
            }
            else
            {
                await context.RespondAsync<OrderAccepted>(new OrderAccepted
                {
                    AcceptBy = "Alireza Oroumand",
                    AcceptDate = DateTime.Now,
                    OrderId = context.Message.OrderId

                });
            }

        }
    }
}
