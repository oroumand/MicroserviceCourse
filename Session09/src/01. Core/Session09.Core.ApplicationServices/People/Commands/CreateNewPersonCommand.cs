using System;
using System.Collections.Generic;

namespace Session09.Core.ApplicationServices.People.Commands
{
    public class CreateNewPersonCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Id { get; set; }


    }
}
