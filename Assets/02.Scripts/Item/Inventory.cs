using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> _inventoryItems = new List<InventoryItem>();    


    public void AddItem(Item item)
    {
        InventoryItem inventoryItem = _inventoryItems.Find(i => i.item.name == item.name);
        // 인벤토리에 아이템이 있는 경우 
        if (inventoryItem != null)
        {
            Debug.Log("Item is in Inventory");
            inventoryItem.count++;
        }
        else
        {
            
            Debug.Log("Item is not in Inventory");
            _inventoryItems.Add(new InventoryItem(item));
        }
    }
}
