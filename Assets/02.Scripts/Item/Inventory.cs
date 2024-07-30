
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    
    class InventoryItem
    {
        string name;
        int count;

        public InventoryItem(string name, int count)
        {
            this.name = name;
            this.count = count;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Count
        {
            get => count;
            set => count = value;
        }
    }

    public void AddItem(Item item)
    {
        // InventoryItems에 item이 들어가 있는지 확인
        InventoryItem inventoryItem = inventoryItems.Find(i => i.Name == item.Name);

        if (inventoryItem == null)
        {
            inventoryItems.Add(new InventoryItem(item.Name, 1));
            Debug.Log($"Added {item.Name} to inventory.");
        }
        else
        {
            if (inventoryItem.Count < item.MaxCount)
            {
                inventoryItem.Count++;
                Debug.Log($"Added {item.Name}. Current count : {inventoryItem.Count}");

            }
            else
            {
                Debug.Log($"Cannot add {item.Name}. Max count reached.");
            }
        }
    }

    public void PrintInventoryItems()
    {
        Debug.Log("Inventory");
        foreach (InventoryItem inventoryItem in inventoryItems)
        {
            Debug.Log($"{inventoryItem.Name} : {inventoryItem.Count }");
        }
    }
}
