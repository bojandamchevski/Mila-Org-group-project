using System;

namespace Shared.CustomExceptions
{
    public class PersonException : Exception
    {
        public PersonException(string message) : base(message)
        {

        }
    }
}
