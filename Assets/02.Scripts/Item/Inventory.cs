using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemSlotPrefab;
    
    private Dictionary<Item, Slot> _inventoryItems = new Dictionary<Item, Slot>();

    
    // Add 가능 여부에 따른 bool 반환 
    public bool Add(Item item)
    {
        // 인벤토리에 아이템 O
        if (_inventoryItems.ContainsKey(item))
        {
            // TODO maxCount를 초과하는 경우 추가 불가능 return false
            Slot slot = _inventoryItems[item];
            
            // 아이템 추가 불가능 
            if (item.MaxCount <= slot.ItemCount)
            {
                Debug.Log("Cannot add item!! " + slot.ItemCount);
                return false;
            }
            // 아이템 개수 증가 
            else
            {
                slot.IncreaseCount();
            }

        }
        // 인벤토리에 아이템 X 
        else
        {
            _inventoryItems.Add(item, InstantiateSlot(item));
        }
        return true;
    }


    
    public Slot InstantiateSlot(Item item)
    {
        // 새 슬롯 생성 
        Transform slotGB = Instantiate(itemSlotPrefab, transform).transform;
        
        Image itemImage = slotGB.Find("ItemImage").gameObject.GetComponent<Image>(); 
        Image outlineImage = slotGB.Find("Outline").gameObject.GetComponent<Image>(); 
        Text itemCountText = slotGB.Find("ItemCount").gameObject.GetComponent<Text>();

        Slot newSlot = new Slot(itemImage, outlineImage, itemCountText);
        newSlot.AttachItemImage(item.Sprite);

        return newSlot;
    }
}
