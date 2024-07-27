
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    
    public class InventoryItem
    {
        public string name;
        public int count;

        public InventoryItem(string name, int count)
        {
            this.name = name;
            this.count = count;
        }
    }

    public void AddItem(Item item)
    {
        // InventoryItems에 item이 들어가 있는지 확인
        InventoryItem inventoryItem = inventoryItems.Find(i => i.name == item.name);

        if (inventoryItem == null)
        {
            inventoryItems.Add(new InventoryItem(item.name, 1));
            Debug.Log($"Added {item.name} to inventory.");
        }
        else
        {
            if (inventoryItem.count < item.maxCount)
            {
                inventoryItem.count++;
                Debug.Log($"Added {item.name}. Current count : {inventoryItem.count}");

            }
            else
            {
                Debug.Log($"Cannot add {item.name}. Max count reached.");
            }
        }
    }

    public void printInventoryItems()
    {
        Debug.Log("Inventory");
        foreach (InventoryItem inventoryItem in inventoryItems)
        {
            Debug.Log($"{inventoryItem.name} : {inventoryItem.count}");
        }
    }
}
