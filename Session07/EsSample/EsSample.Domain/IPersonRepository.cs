using System;
using System.Collections.Generic;
using System.Text;

namespace EsSample.Domain
{
    public interface IPersonRepository
    {
        void Save(Person person);
        Person Get(Guid guid);
    }
}
