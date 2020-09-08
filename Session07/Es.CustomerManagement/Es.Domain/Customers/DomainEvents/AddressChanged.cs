using Es.Framework;

namespace Session07.Es.CustomerManagement.Domain.People.DomainEvents
{
    public class AddressChanged : IDomainEvent
    {
        public string City { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public string Street { get; }
        public string CustomerId { get; }
        public AddressChanged(string customerId,
            string city,
            string country,
            string zipcode,
            string street)
        {
            CustomerId = customerId;
            City = city;
            Country = country;
            ZipCode = zipcode;
            Street = street;
        }
    }
}
