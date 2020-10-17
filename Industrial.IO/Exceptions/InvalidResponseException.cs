
namespace Industrial
{
    using System;

    public class InvalidResponseException : Exception
    {
        public InvalidResponseException() : base() { }

        public InvalidResponseException(string message) : base(message) { }
    }
}
