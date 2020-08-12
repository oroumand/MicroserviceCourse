using EsSample.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsSample.Domain
{
    public class Person : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool IsMale { get; private set; }

        private Person()
        {

        }
        public static Person LoadByEvents(List<IDomainEvent> domainEvents)
        {
            var person = new Person();
            foreach (var @event in domainEvents)
            {
                switch (@event)
                {
                    case PersonCreated personCreated:
                        person.Id = personCreated.Id;
                        person.FirstName = personCreated.FirstName;
                        person.LastName = personCreated.LastName;
                        break;
                    case BirthDateUpdated birthDateUpdated:
                        person.BirthDate = birthDateUpdated.BirthDate;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            return person;
        }
        public static Person Create(Guid id, string firstName, string lastName)
        {
            var person = new Person
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
            };
            person.AddEvent(new PersonCreated
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            });
            return person;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            BirthDate = BirthDate;
            AddEvent(new BirthDateUpdated
            {
                BirthDate = birthDate,
                Id = Id
            });
        }
    }
}
