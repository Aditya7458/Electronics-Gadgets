using System;

namespace OrderManagementSystem
{
    public class Products
    {
        private int productId;
        private string productName;
        private string description;
        private decimal price;
        private int stockQuantity;
        public Products(int productId, string productName, string description, decimal price, int stockQuantity)
        {
            this.ProductID = productId;
            this.ProductName = productName;
            this.Description = description;
            this.Price = price;
            this.StockQuantity = stockQuantity;
        }

        public int ProductID
        {
            get { return productId; }
            private set { productId = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative.");
                price = value;
            }
        }

        public int StockQuantity
        {
            get { return stockQuantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Stock quantity cannot be negative.");
                stockQuantity = value;
            }
        }

        // Methods
        public void GetProductDetails()
        {
            Console.WriteLine($"Product ID: {ProductID}, Name: {ProductName}, Description: {Description}, Price: {Price}, Stock: {StockQuantity}");
        }

        public void UpdateProductInfo(string newDescription, decimal newPrice)
        {
            this.Description = newDescription;
            this.Price = newPrice;
        }

        public bool IsProductInStock()
        {
            return StockQuantity > 0;
        }
    }
}
