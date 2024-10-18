using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace YourNamespace.util;

public class TechShopOperations
{
    private string _connectionString = DBPropertyUtil.GetConnectionString("dbProperties.txt");

    public void RegisterCustomer(string firstName, string lastName, string email, string phone, string address)
    {
        using (var conn = DBConnUtil.GetDBConn(_connectionString))
        {
            var cmd = new SqlCommand("INSERT INTO Customers (FirstName, LastName, Email, Phone, Address) VALUES (@FirstName, @LastName, @Email, @Phone, @Address)", conn);
            cmd.Parameters.AddWithValue("@FirstName", firstName);
            cmd.Parameters.AddWithValue("@LastName", lastName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Address", address);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine("Customer registered successfully.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) 
                {
                    Console.WriteLine("Error: Email already exists.");
                }
                else
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }

    public void ManageProductCatalog()
    {
        // Implement product management operations here (insert, update, delete)
    }

    public void PlaceCustomerOrder(int customerId, int productId, int quantity)
    {
        using (var conn = DBConnUtil.GetDBConn(_connectionString))
        {
            // Assuming order total will be calculated later based on product price
            var cmd = new SqlCommand("INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) OUTPUT INSERTED.OrderID VALUES (@CustomerId, @OrderDate, @TotalAmount)", conn);
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@TotalAmount", 0); // Placeholder, to be updated later

            try
            {
                int orderId = (int)cmd.ExecuteScalar();
                Console.WriteLine($"Order placed successfully. Order ID: {orderId}");

                // Update order details
                var detailCmd = new SqlCommand("INSERT INTO OrderDetails (OrderID, ProductID, Quantity) VALUES (@OrderId, @ProductId, @Quantity)", conn);
                detailCmd.Parameters.AddWithValue("@OrderId", orderId);
                detailCmd.Parameters.AddWithValue("@ProductId", productId);
                detailCmd.Parameters.AddWithValue("@Quantity", quantity);
                detailCmd.ExecuteNonQuery();

                // Update order total
                UpdateOrderTotal(orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public void UpdateOrderTotal(int orderId)
    {
        using (var conn = DBConnUtil.GetDBConn(_connectionString))
        {
            var cmd = new SqlCommand("UPDATE Orders SET TotalAmount = (SELECT SUM(OrderDetails.Quantity * Products.Price) FROM OrderDetails JOIN Products ON OrderDetails.ProductID = Products.ProductID WHERE OrderDetails.OrderID = @OrderId) WHERE OrderID = @OrderId", conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            cmd.ExecuteNonQuery();
        }
    }

    public void TrackOrderStatus(int orderId)
    {
        using (var conn = DBConnUtil.GetDBConn(_connectionString))
        {
            var cmd = new SqlCommand("SELECT Status FROM Orders WHERE OrderID = @OrderId", conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);

            var status = cmd.ExecuteScalar();
            Console.WriteLine($"Order Status: {status}");
        }
    }

    // Implement other methods based on the tasks specified (e.g., Inventory Management, Sales Reporting, etc.)
}
