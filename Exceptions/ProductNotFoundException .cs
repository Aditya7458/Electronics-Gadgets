// File: Exceptions/ProductNotFoundException.cs
using System;

namespace Exceptions
{
    // Custom exception for product not found cases
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base() { }

        public ProductNotFoundException(string message) : base(message) { }

        public ProductNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
