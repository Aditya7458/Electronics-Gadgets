using System;

namespace Exceptions
{
    // Custom Exception for Customer-related issues
    public class CustomerException : Exception
    {
        public CustomerException() : base() { }

        public CustomerException(string message) : base(message) { }

        public CustomerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
