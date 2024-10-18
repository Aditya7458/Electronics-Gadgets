//using System;
//using System.Collections.Generic;

//public class InventoryManager
//{
//    private SortedList<int, Inventory> inventoryList;

//    public InventoryManager()
//    {
//        inventoryList = new SortedList<int, Inventory>();
//    }

//    public void AddInventory(int productId, int quantity)
//    {
//        if (inventoryList.ContainsKey(productId))
//        {
//            inventoryList[productId].AddToInventory(quantity);
//        }
//        else
//        {
//            var newInventory = new Inventory(inventoryList.Count + 1, new Product(productId, "Product", 0), quantity);
//            inventoryList.Add(productId, newInventory);
//        }
//    }

//    public void RemoveFromInventory(int productId, int quantity)
//    {
//        if (inventoryList.ContainsKey(productId))
//        {
//            inventoryList[productId].RemoveFromInventory(quantity);
//        }
//        else
//        {
//            throw new Exception("Product not in inventory.");
//        }
//    }

//    public void ListInventory()
//    {
//        foreach (var inventory in inventoryList.Values)
//        {
//            inventory.GetInventoryDetails();
//        }
//    }

//    public void ListLowStockProducts(int threshold)
//    {
//        foreach (var inventory in inventoryList.Values)
//        {
//            if (inventory.QuantityInStock < threshold)
//            {
//                inventory.GetInventoryDetails();
//            }
//        }
//    }

//    public void ListOutOfStockProducts()
//    {
//        foreach (var inventory in inventoryList.Values)
//        {
//            if (inventory.QuantityInStock == 0)
//            {
//                inventory.GetInventoryDetails();
//            }
//        }
//    }
//}
