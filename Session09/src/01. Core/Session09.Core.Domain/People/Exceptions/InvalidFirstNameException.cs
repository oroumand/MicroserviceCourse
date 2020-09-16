using System;
using System.Collections.Generic;
using System.Text;

namespace Session09.Core.Domain.People.Exceptions
{
    public class InvalidFirstNameException : Zamin.Core.Domain.Exceptions.InvalidEntityStateException
    {
        public InvalidFirstNameException(string message, params string[] parameters) : base(message, parameters)
        {
        }
    }
}
