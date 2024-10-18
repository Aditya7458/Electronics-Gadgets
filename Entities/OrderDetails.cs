using System;

namespace OrderManagementSystem
{
    public class OrderDetails
    {
        // Private fields for encapsulation
        private int orderDetailId;
        private Orders order;  // Composition relationship
        private Products product;  // Composition relationship
        private int quantity;

        // Constructor to initialize attributes
        public OrderDetails(int orderDetailId, Orders order, Products product, int quantity)
        {
            this.OrderDetailID = orderDetailId;
            this.Order = order;
            this.Product = product;
            this.Quantity = quantity;
        }

        // Public properties with data validation
        public int OrderDetailID
        {
            get { return orderDetailId; }
            private set { orderDetailId = value; }
        }

        public Orders Order
        {
            get { return order; }
            set { order = value; }
        }

        public Products Product
        {
            get { return product; }
            set { product = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Quantity must be greater than zero.");
                quantity = value;
            }
        }

        // Methods
        public decimal CalculateSubtotal()
        {
            return Product.Price * Quantity;
        }

        public void GetOrderDetailInfo()
        {
            Console.WriteLine($"Order Detail ID: {OrderDetailID}, Product: {Product.ProductName}, Quantity: {Quantity}, Subtotal: {CalculateSubtotal():C}");
        }

        public void UpdateQuantity(int newQuantity)
        {
            this.Quantity = newQuantity;
        }

        public void AddDiscount(decimal discountAmount)
        {
            // Placeholder logic: In reality, discount would reduce subtotal based on rules
            Console.WriteLine($"Discount of {discountAmount:C} applied to the order detail.");
        }
    }
}
