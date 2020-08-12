using System;
using System.Collections.Generic;
using EsSample.Domain;
using EsSample.Framework;

namespace EsSample.Dal
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IEventStore _eventStore;

        public PersonRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        public Person Get(Guid guid)
        {
            var eventItems = _eventStore.Get(guid.ToString(), typeof(Person).Name);
            var domainEvents = new List<IDomainEvent>();
            foreach (var item in eventItems)
            {
                switch (item.EventType)
                {
                    case nameof(PersonCreated):
                        PersonCreated personCreated = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonCreated>(item.EventSerializedData);
                        domainEvents.Add(personCreated);
                        break;
                    case nameof(BirthDateUpdated):
                        BirthDateUpdated personEmailUpdate = Newtonsoft.Json.JsonConvert.DeserializeObject<BirthDateUpdated>(item.EventSerializedData);
                        domainEvents.Add(personEmailUpdate);

                        break;
                }
            }
            return Person.LoadByEvents(domainEvents);
        }

        public void Save(Person person)
        {
            _eventStore.AddEvents(person.GetEvents(), person.Id.ToString(), person.GetType().Name);
        }
    }
}
