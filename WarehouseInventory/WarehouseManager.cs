using System;
using WarehouseInventory.Exceptions;
using WarehouseInventory.Models;
using WarehouseInventory.Repositories;

namespace WarehouseInventory
{
    public class WarehouseManager
    {
        public readonly InventoryRepository<ElectronicItem> Electronics = new();
        public readonly InventoryRepository<GroceryItem> Groceries = new();

        public void SeedData()
        {
            // Electronics
            Electronics.AddItem(new ElectronicItem(101, "Wireless Earbuds", 50, "Sony", 12));
            Electronics.AddItem(new ElectronicItem(102, "Smart Watch", 30, "Samsung", 24));

            // Groceries
            Groceries.AddItem(new GroceryItem(201, "Organic Apples", 200, DateTime.Now.AddDays(14)));
            Groceries.AddItem(new GroceryItem(202, "Whole Grain Bread", 150, DateTime.Now.AddDays(7)));
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            Console.WriteLine($"\n=== {typeof(T).Name.ToUpper()} INVENTORY ===");
            foreach (var item in repo.GetAllItems())
            {
                Console.WriteLine(item);
            }
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Updated {item.Name}: New quantity = {item.Quantity + quantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.RemoveItem(id);
                Console.WriteLine($"Removed: {item.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}