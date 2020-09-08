using Es.Framework;
using Session07.Es.CustomerManagement.Domain.Customers.ValueObjects;
using Session07.Es.CustomerManagement.Domain.People.DomainEvents;
using System;
using System.Collections.Generic;

namespace Session07.Es.CustomerManagement.Domain.Customers.Entities
{
    public class Customer : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address CustomerAddress { get; private set; }

        public Customer(IEnumerable<IDomainEvent> events) : base(events)
        {
        }

        private Customer()
        {

        }

        public static Customer CreateCustomer(
            string firstName,
            string lastName)
        {

            var customer = new Customer();
            customer.Apply(new CustomerCreated(Guid.NewGuid().ToString(), firstName, lastName));
            return customer;
        }
        public void ChangeName(string firstName, string lastName)
        {
            Apply(new CustomerNameChanged(Id.ToString(), firstName, lastName));
        }
        public void ChangeAddress(string street, string country, string zipCode, string city)
        {
            Apply(new AddressChanged(Id.ToString(), city, country, zipCode, street));
        }



        public void On(CustomerCreated @event)
        {
            Id = Guid.Parse(@event.CustomerId);
            FirstName = @event.FirstName;
            LastName = @event.LastName;
        }

        public void On(CustomerNameChanged @event)
        {
            Id = Guid.Parse(@event.CustomerId);
            FirstName = @event.FirstName;
            LastName = @event.LastName;
        }

        public void On(AddressChanged @event)
        {
            CustomerAddress = new Address()
            {
                City = @event.City,
                Country = @event.Country,
                Street = @event.Street,
                ZipCode = @event.ZipCode
            };
        }
    }
}
