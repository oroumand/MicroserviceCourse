namespace Session09.Core.Domain.People.Exceptions
{
    public class InvalidPersonIdException : Zamin.Core.Domain.Exceptions.InvalidEntityStateException
    {
        public InvalidPersonIdException(string message, params string[] parameters) : base(message, parameters)
        {
        }
    }
}
