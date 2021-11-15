using System;

namespace Shared.CustomExceptions
{
    public class ChapterException : Exception
    {
        public ChapterException(string message) : base(message)
        {

        }
    }
}
