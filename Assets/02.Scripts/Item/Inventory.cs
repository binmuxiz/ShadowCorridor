
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public InventoryUI inventoryUI;


    // Inventory Database에 저장하는 개념인가? 왜 필요한건지 모르겠음

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

                // InventoryList에 InventoryItem 추가
                InventoryItem newItem = new InventoryItem(item.name, 1);
                inventoryItems.Add(newItem);
                Debug.Log($"Added {item.name} to inventory.");

                // UI에 아이템 추가
                inventoryUI.AddItemUI(newItem);

            }
        }
    }
}
