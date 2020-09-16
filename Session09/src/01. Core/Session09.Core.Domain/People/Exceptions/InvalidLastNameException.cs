namespace Session09.Core.Domain.People.Exceptions
{
    public class InvalidLastNameException : Zamin.Core.Domain.Exceptions.InvalidEntityStateException
    {
        public InvalidLastNameException(string message, params string[] parameters) : base(message, parameters)
        {
        }
    }
}
