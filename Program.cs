using Microsoft.Data.SqlClient;
namespace YourNamespace.util;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        TechShopOperations operations = new TechShopOperations();

        // Example of customer registration
        //operations.RegisterCustomer("John", "Doe", "john.doe@example.com", "9876543210", "123 Elm Street");

        // Example of placing an order
        //operations.PlaceCustomerOrder(1, 1, 1); // CustomerID = 1, ProductID = 1, Quantity = 1

        // Example of tracking order status
        operations.TrackOrderStatus(1);
    }
}
