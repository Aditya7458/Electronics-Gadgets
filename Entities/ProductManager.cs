using System;
using System.Collections.Generic;
using System.Linq;
using OrderManagementSystem;
using Exceptions; 

namespace Manager
{
    public class ProductManager
    {
        private List<Products> products;

        public ProductManager()
        {
            products = new List<Products>();
        }

        // Method to add a product
        public void AddProduct(Products product)
        {
            if (products.Any(p => p.ProductID == product.ProductID))
            {
                throw new ProductNotFoundException("Product with the same ID already exists.");
            }
            products.Add(product);
        }

        // Method to update a product
        public void UpdateProduct(Products product)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductID == product.ProductID);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException("Product not found.");
            }

            existingProduct.ProductName = product.ProductName;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
        }

        // Method to remove a product
        public void RemoveProduct(int productId)
        {
            var product = products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                throw new ProductNotFoundException("Product not found.");
            }
            products.Remove(product);
        }

        // Method to search for a product by name
        public List<Products> SearchProductsByName(string name)
        {
            return products.Where(p => p.ProductName.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Method to list all products
        public List<Products> ListAllProducts()
        {
            return products;
        }
    }
}
