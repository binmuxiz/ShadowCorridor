
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public InventoryUI inventoryUI;
    
    
    // Inventory Database에 저장하는 개념인가? 왜 필요한건지 모르겠음
    public void AddItem(Item item)
    {
        // InventoryItems에 item이 들어가 있는지 확인
        InventoryItem inventoryItem = inventoryItems.Find(i => i.name == item.name);

        if (inventoryItem == null)
        {
            // InventoryList에 InventoryItem 추가
            InventoryItem newItem = new InventoryItem(item.name, 1); 
            inventoryItems.Add(newItem);
            Debug.Log($"Added {item.name} to inventory.");
            
            // UI에 아이템 추가
            inventoryUI.AddItemUI(newItem);

        }
        else
        {
            if (inventoryItem.count == -1 || inventoryItem.count < item.maxCount)
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
