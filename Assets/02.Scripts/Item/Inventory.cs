using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemSlotPrefab;

    // TODO Capacity 설정 
    private List<Slot> _slotList = new List<Slot>();
    
    public List<Slot> SlotList => _slotList;

    public int SlotCount()
    {
        return _slotList.Count;
    }

    // Add 가능 여부에 따른 bool 반환 
    public bool AddSlot(Item item)
    {
        Slot slot = null;
        foreach (var s in _slotList)
        {
            if (item == s.Item) slot = s;   // 아이템 있는 경우 
        }
        
        if (slot == null) // 인벤토리 슬롯 생성 
        {
            slot = InstantiateSlot(item);
            slot.Item = item;
            _slotList.Add(slot);
        }
        else 
        {
            if (slot.Item.MaxCount <= slot.ItemCount)
            {
                // 아이템 추가 불가
                Debug.Log("Cannot add item!! " + slot.ItemCount);
                return false;
            }
            // 인벤토리 아이템 개수 증가 
            slot.IncreaseCount();
        }
        return true;
    }
    
    public void DeleteSlot(int idx)
    {
        
    }


    
    private Slot InstantiateSlot(Item item)
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
