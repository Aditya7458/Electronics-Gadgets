using System;

namespace Exceptions
{
    // Custom Exception for Inventory-related issues
    public class InventoryException : Exception
    {
        public InventoryException() : base() { }

        public InventoryException(string message) : base(message) { }

        public InventoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
