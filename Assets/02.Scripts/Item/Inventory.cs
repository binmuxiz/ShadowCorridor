using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public GameObject itemSlotPrefab;

    private int _currentIdx = 0;
    private List<Slot> _slotList = new List<Slot>(); // TODO Capacity 설정


    private void Awake()
    {
        Instance = this;
    }

    public int CurrentIdx
    {
        get => _currentIdx;
        set => _currentIdx = value;
    }

    public List<Slot> SlotList => _slotList;

    private void Start()
    {
        CreateDefaultItem();
    }
    
    private void CreateDefaultItem()
    {
        // Flashlight 슬롯 생성 
        Item item = ItemDatabase.Instance.FindItemByName("Flashlight");
        AddSlot(item);
        _slotList[0].ToggleOutline();
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
    
        
    public void SelectRightSlot()
    {
        if (_currentIdx + 1 < SlotCount())
        {
            SlotList[_currentIdx].ToggleOutline();
            SlotList[++_currentIdx].ToggleOutline();
        }
    }
    
    public void SelectLeftSlot()
    {
        if (_currentIdx - 1 >= 0)
        {
            SlotList[_currentIdx].ToggleOutline();
            SlotList[--_currentIdx].ToggleOutline();
        }
    }
}
