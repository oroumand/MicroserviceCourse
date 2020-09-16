using Session09.Core.Domain.People.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Zamin.Core.Domain.TacticalPatterns;

namespace Session09.Core.Domain.People.Repositories
{
    public interface IPersonCommandRepository
    {
        public void Add(Person person);
        public Person Get(BusinessId id);
    }
}
