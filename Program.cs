using Microsoft.Data.SqlClient;
namespace YourNamespace.util;

using Manager;
using OrderManagementSystem;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        TechShopOperations operations = new TechShopOperations();
        ProductManager productManager = new ProductManager();

        // Example of customer registration
        //operations.RegisterCustomer("John", "Doe", "john.doe@example.com", "9876543210", "123 Elm Street");

        // Example of placing an order
        //operations.PlaceCustomerOrder(1, 1, 1); // CustomerID = 1, ProductID = 1, Quantity = 1


        //operations.TrackOrderStatus(1);
        //operations.RecordPayment(1, 1100, "Credit Card");
        //customerManager.UpdateCustomerAccount(1, "newemail@example.com", "1234567890");

        // Product Catalog and Inventory Management
        //productManager.AddProduct(1, "Laptop", "High-performance laptop", 1000, 10);
        //Products newProduct = new Products(0,"Desktop", "High-Refrest Rate Desktop", 1000, 10);
        //productManager.AddProduct(newProduct);

        //Products updatedProduct = new Products(1, "Laptop", "Updated description", 1100, 10);
        //productManager.UpdateProduct(updatedProduct);

        //var productList = productManager.ListAllProducts();
        //foreach (var product in productList)
        {
            product.GetProductDetails();
        }
    }
}
