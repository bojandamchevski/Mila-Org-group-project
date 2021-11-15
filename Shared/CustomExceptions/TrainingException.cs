using System;

namespace Shared.CustomExceptions
{
    public class TrainingException : Exception
    {
        public TrainingException(string message) : base(message)
        {

        }
    }
}
