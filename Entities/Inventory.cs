using System;

namespace OrderManagementSystem
{
    public class Inventory
    {
        private int inventoryId;
        private Products product;  
        private int quantityInStock;

        public Inventory(int inventoryId, Products product, int quantityInStock)
        {
            this.InventoryID = inventoryId;
            this.Product = product;
            this.QuantityInStock = quantityInStock;
        }
        public int InventoryID
        {
            get { return inventoryId; }
            private set { inventoryId = value; }
        }

        public Products Product
        {
            get { return product; }
            set { product = value; }
        }

        public int QuantityInStock
        {
            get { return quantityInStock; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity in stock cannot be negative.");
                quantityInStock = value;
            }
        }
        public void AddToInventory(int quantity)
        {
            QuantityInStock += quantity;
        }

        public void RemoveFromInventory(int quantity)
        {
            if (quantity > QuantityInStock)
                throw new ArgumentException("Cannot remove more than available stock.");
            QuantityInStock -= quantity;
        }

        public void ListAllProducts()
        {
            Console.WriteLine($"Product: {Product.ProductName}, Stock: {QuantityInStock}");
        }

        public void ListLowStockProducts(int threshold)
        {
            if (QuantityInStock <= threshold)
                Console.WriteLine($"Product: {Product.ProductName} has low stock: {QuantityInStock}");
        }
    }
}
