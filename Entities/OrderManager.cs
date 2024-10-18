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
        public void AddOrder(Orders order)
        {
            orders.Add(order);
        }

        public void UpdateOrderStatus(int orderId, string newStatus)
        {
            var order = orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                throw new OrderNotFoundException("Order not found.");
            }

            order.Status = newStatus;
        }

        public void RemoveOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                throw new OrderNotFoundException("Order not found.");
            }
            orders.Remove(order);
        }

        public List<Orders> SortOrdersByDate(bool ascending = true)
        {
            return ascending ? orders.OrderBy(o => o.OrderDate).ToList() : orders.OrderByDescending(o => o.OrderDate).ToList();
        }
        public List<Orders> ListAllOrders()
        {
            return orders;
        }
    }
}
