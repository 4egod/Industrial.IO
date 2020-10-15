#if MF 
namespace System
{
    public class TimeoutException : Exception
    {
        public TimeoutException() : base() { }

        public TimeoutException(string message) : base(message) { }
    }
}
#endif