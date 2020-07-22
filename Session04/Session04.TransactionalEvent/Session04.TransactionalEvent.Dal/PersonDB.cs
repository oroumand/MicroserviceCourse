using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Session04.TransactionalEvent.Common;
using Session04.TransactionalEvent.Domain.People;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Session04.TransactionalEvent.Dal
{
    public class PersonDB : DbContext
    {
        public PersonDB(DbContextOptions<PersonDB> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<OutBoxEvent> OutBoxEvents { get; set; }

        public override int SaveChanges()
        {
            List<BaseEntity> modifiedEntities = GetModifiedEntities();
            AddEventsToOutBox(modifiedEntities);
            return base.SaveChanges();
        }

        private void AddEventsToOutBox(List<BaseEntity> modifiedEntities)
        {
            foreach (var entity in modifiedEntities)
            {
                var events = entity.GetEvents();
                foreach (var domainEvent in events)
                {
                    OutBoxEvents.Add(new OutBoxEvent
                    {
                        EventDate = DateTime.Now,
                        EventData = JsonConvert.SerializeObject(domainEvent),
                        EventType = domainEvent.GetType().FullName,
                        StreamId = entity.Id.ToString(),
                        StreamName = entity.GetType().Name
                    });
                }
            }
        }

        private List<BaseEntity> GetModifiedEntities()=>
             ChangeTracker.Entries<BaseEntity>().Where(x => x.State != EntityState.Detached).Select(c => c.Entity).Where(c => c.GetEvents().Any()).ToList();
        
    }
}
