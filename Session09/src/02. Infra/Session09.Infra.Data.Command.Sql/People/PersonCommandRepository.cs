using Session09.Core.Domain.People.Entities;
using Session09.Core.Domain.People.Repositories;
using System.Linq;
using Zamin.Core.Domain.TacticalPatterns;

namespace Session09.Infra.Data.Command.Sql.People
{
    public class PersonCommandRepository : IPersonCommandRepository
    {
        private readonly Session09DbContext dbContext;

        public PersonCommandRepository(Session09DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Person person)
        {
            dbContext.People.Add(person);
            dbContext.SaveChanges();
        }

        public Person Get(BusinessId id)
        {
            return dbContext.People.FirstOrDefault(c => c.Id == id);
        }
    }
}
