using System;

namespace Shared.CustomExceptions
{
    public class ResearchException : Exception
    {
        public ResearchException(string message) : base(message)
        {

        }
    }
}
