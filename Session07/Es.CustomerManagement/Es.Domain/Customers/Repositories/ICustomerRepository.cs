using Session07.Es.CustomerManagement.Domain.Customers.Entities;
using System;
using System.Threading.Tasks;

namespace Session07.Es.CustomerManagement.Domain.Customers.Repositories
{
    public interface ICustomerRepository
    {
        Task<Guid> SaveAsync(Customer customer);
        Task<Customer> GetCustomer(Guid id);
    }
}
