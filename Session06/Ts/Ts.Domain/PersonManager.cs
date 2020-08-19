using System;

namespace Ts.Domain
{
    public class PersonManager
    {
        public bool RegistPerson(string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            string temp = firstName.Substring(0, 2) + lastName.Substring(0, 2);
            //SaveToDb

            return true;
        }
    }
}
