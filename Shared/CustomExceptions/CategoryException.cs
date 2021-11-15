using System;

namespace Shared.CustomExceptions
{
    public class CategoryException : Exception
    {
        public CategoryException(string message) : base(message)
        {

        }
    }
}
