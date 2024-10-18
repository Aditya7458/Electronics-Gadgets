using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using OrderManagementSystem; 
using Exceptions; 

namespace Manager
{
    public class ProductManager
    {
        // Connection string for database
        private string connectionString = DBPropertyUtil.GetConnectionString("dbProperties.txt");

        // Method to add a product to the database
        public void AddProduct(Products product)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName, Description, Price, StockQuantity) VALUES (@ProductName, @Description, @Price, @StockQuantity)", conn);

                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Product added successfully.");
                }
                catch (SqlException ex)
                {
                    throw new ProductNotFoundException("Error adding product: " + ex.Message);
                }
            }
        }

        // Method to update an existing product in the database
        public void UpdateProduct(Products product)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Products SET ProductName = @ProductName, Description = @Description, Price = @Price, StockQuantity = @StockQuantity WHERE ProductID = @ProductID", conn);

                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ProductNotFoundException("Product not found.");
                }
                else
                {
                    Console.WriteLine("Product updated successfully.");
                }
            }
        }

        // Method to remove a product from the database
        public void RemoveProduct(int productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductID = @ProductID", conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ProductNotFoundException("Product not found.");
                }
                else
                {
                    Console.WriteLine("Product removed successfully.");
                }
            }
        }

        // Method to search products by name in the database
        public List<Products> SearchProductsByName(string name)
        {
            List<Products> productList = new List<Products>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ProductID, ProductName, Description, Price, StockQuantity FROM Products WHERE ProductName LIKE @ProductName", conn);
                cmd.Parameters.AddWithValue("@ProductName", "%" + name + "%");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products product = new Products(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetInt32(4)
                        );
                        productList.Add(product);
                    }
                }
            }

            return productList;
        }

        // Method to list all products from the database
        public List<Products> ListAllProducts()
        {
            List<Products> productList = new List<Products>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ProductID, ProductName, Description, Price, StockQuantity FROM Products", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Products product = new Products(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetDecimal(3),
                            reader.GetInt32(4)
                        );
                        productList.Add(product);
                    }
                }
            }

            return productList;
        }
    }
}
