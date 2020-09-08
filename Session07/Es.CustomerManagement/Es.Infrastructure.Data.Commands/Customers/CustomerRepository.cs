using Es.Framework;
using Session07.Es.CustomerManagement.Domain.Customers.Entities;
using Session07.Es.CustomerManagement.Domain.Customers.Repositories;
using System;
using System.Threading.Tasks;

namespace Session07.Es.CustomerManagement.Infrastructure.Data.Commands.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IEventStore eventStore;

        public CustomerRepository(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }
        public async Task<Customer> GetCustomer(Guid id)
        {
            var customerEvents = await eventStore.LoadAsync(id, typeof(Customer).Name);
            return new Customer(customerEvents);
        }

        public async Task<Guid> SaveAsync(Customer customer)
        {
            await eventStore.SaveAsync(customer.Id, customer.GetType().Name, customer.Version, customer.DomainEvents);
            return customer.Id;
        }
    }
}
