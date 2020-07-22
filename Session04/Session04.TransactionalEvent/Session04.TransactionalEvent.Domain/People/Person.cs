using Session04.TransactionalEvent.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.TransactionalEvent.Domain.People
{
    public class Person: BaseEntity
    {
        public string FirstName { get;private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool IsMale { get; private set; }

        private  Person()
        {

        }

        public Person(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AddEvent(new PersonCreated
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            });

        }

        public void SetBirthDate(DateTime birthDate)
        {
            BirthDate = BirthDate;
            AddEvent(new BirthDateUpdated
            {
                BirthDate = birthDate,
                Id = this.Id
            });
        }
    }
}
