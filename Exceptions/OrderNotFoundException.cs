using System;

namespace Exceptions
{
    public class OrderNotFoundException : OrderException
    {
        public OrderNotFoundException() : base() { }

        public OrderNotFoundException(string message) : base(message) { }

        public OrderNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
