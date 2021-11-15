using System;

namespace Shared.CustomExceptions
{
    public class BlogException : Exception
    {
        public BlogException(string message) : base(message)
        {

        }
    }
}
