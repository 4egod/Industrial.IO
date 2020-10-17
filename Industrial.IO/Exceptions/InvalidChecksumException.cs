
namespace Industrial
{
    using System;

    public class InvalidChecksumException : Exception
    {
        public InvalidChecksumException() : base() { }

        public InvalidChecksumException(string message) : base(message) { }
    }
}
