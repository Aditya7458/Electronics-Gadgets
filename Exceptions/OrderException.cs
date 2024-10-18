using System;

namespace Exceptions
{
    public class OrderException : Exception
    {
        public OrderException() : base() { }

        public OrderException(string message) : base(message) { }

        public OrderException(string message, Exception innerException) : base(message, innerException) { }
    }
}
