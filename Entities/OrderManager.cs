using Exceptions;
using OrderManagementSystem;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Manager
{
    public class OrderManager
    {
        private List<Orders> orders;

        public OrderManager()
        {
            orders = new List<Orders>();
        }

        // Method to add an order
        public void AddOrder(Orders order)
        {
            orders.Add(order);
        }

        // Method to update order status
        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            var order = orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                throw new OrderNotFoundException("Order not found.");
            }

            order.Status = newStatus; // Assuming Status is a property of Order
        }

        // Method to remove an order
        public void RemoveOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                throw new OrderNotFoundException("Order not found.");
            }
            orders.Remove(order);
        }

        // Method to sort orders by date
        public List<Orders> SortOrdersByDate(bool ascending = true)
        {
            return ascending ? orders.OrderBy(o => o.OrderDate).ToList() : orders.OrderByDescending(o => o.OrderDate).ToList();
        }

        // Method to list all orders
        public List<Orders> ListAllOrders()
        {
            return orders;
        }
    }
}
