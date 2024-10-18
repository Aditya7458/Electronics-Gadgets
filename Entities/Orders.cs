using System;
using System.Collections.Generic;

namespace OrderManagementSystem
{
    public class Orders
    {
        private int orderId;
        private Customers customer;  
        private DateTime orderDate;
        private List<OrderDetails> orderDetails;  
        private decimal totalAmount;
        private string status;

        public Orders(int orderId, Customers customer, DateTime orderDate)
        {
            this.OrderID = orderId;
            this.Customer = customer;
            this.OrderDate = orderDate;
            this.orderDetails = new List<OrderDetails>();  
            this.Status = "Processing"; 
        }

        public int OrderID
        {
            get { return orderId; }
            private set { orderId = value; }
        }

        public Customers Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public decimal TotalAmount
        {
            get { return 5; }
            private set { totalAmount = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public void AddOrderDetail(OrderDetails orderDetail)
        {
            orderDetails.Add(orderDetail);
            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var detail in orderDetails)
            {
                TotalAmount += detail.CalculateSubtotal();
            }
        }

        public void GetOrderDetails()
        {
            Console.WriteLine($"Order ID: {OrderID}, Customer: {Customer.FirstName} {Customer.LastName}, Date: {OrderDate}, Total Amount: {TotalAmount}, Status: {Status}");
            Console.WriteLine("Order Details:");
            foreach (var detail in orderDetails)
            {
                detail.GetOrderDetailInfo();
            }
        }

        public void UpdateOrderStatus(string newStatus)
        {
            this.Status = newStatus;
        }

        public void CancelOrder()
        {
            this.Status = "Cancelled";
            Console.WriteLine("Order has been cancelled.");
        }
    }
}
