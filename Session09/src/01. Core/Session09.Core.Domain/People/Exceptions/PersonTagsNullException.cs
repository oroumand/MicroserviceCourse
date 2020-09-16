namespace Session09.Core.Domain.People.Exceptions
{
    public class PersonTagsNullException : Zamin.Core.Domain.Exceptions.InvalidEntityStateException
    {
        public PersonTagsNullException(string message, params string[] parameters) : base(message, parameters)
        {
        }
    }
}
