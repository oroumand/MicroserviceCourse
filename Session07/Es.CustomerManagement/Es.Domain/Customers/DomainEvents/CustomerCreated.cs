using Es.Framework;

namespace Session07.Es.CustomerManagement.Domain.People.DomainEvents
{
    public class CustomerCreated : IDomainEvent
    {
        public string CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public CustomerCreated(
            string customerId,
            string firstName,
            string lastName)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
