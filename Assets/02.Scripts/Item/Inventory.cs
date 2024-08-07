using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Slot> SlotList => _slotList;
    public GameObject itemSlotPrefab;
    
    private int _currentIdx = 0;
    private List<Slot> _slotList = new List<Slot>(); // TODO Capacity 설정 

    public int CurrentIdx
    {
        get => _currentIdx;
        set => _currentIdx = value;
    }

    public void Start()
    {
        Debug.Log("Inventory Start()");
    }

    private void Update()
    {
        // Debug.Log("현재 아이템슬롯 개수 : " + SlotCount());
        
        if (SlotCount() == 1) return;
        
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
                                         
        if (wheelInput > 0) // 휠을 올렸을 때 : 오른쪽 아이템 선택
        { 
            
            if (_currentIdx + 1 < SlotCount())
            {
                SlotList[_currentIdx].ToggleOutline();
                SlotList[++_currentIdx].ToggleOutline();
            }
            // Debug.Log("currentIdx : " + _currentIdx);
        }
        
        else if (wheelInput < 0) // 휠을 내렸을 때 : 왼쪽 아이템 선택 
        {
            if (_currentIdx - 1 >= 0)
            {
                SlotList[_currentIdx].ToggleOutline();
                SlotList[--_currentIdx].ToggleOutline();
            }
            // Debug.Log("currentIdx : " + _currentIdx);
        }
    }

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
                // Debug.Log("Cannot add item!! " + slot.ItemCount); // 아이템 추가 불가
                return false;
            }
            // 인벤토리 아이템 개수 증가 
            slot.IncreaseCount();
        }
        return true;
    }
    
    public void DeleteSlot(int index)
    {
        Destroy(transform.GetChild(index).gameObject);
        _slotList.RemoveAt(index);
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
