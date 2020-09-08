using Es.Framework;

namespace Session07.Es.CustomerManagement.Domain.People.DomainEvents
{
    public class CustomerNameChanged : IDomainEvent
    {
        public string CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public CustomerNameChanged(
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
