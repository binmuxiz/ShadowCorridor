using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public GameObject itemSlotPrefab;

    private int _currentIdx = 0;
    private List<Slot> _slotList = new List<Slot>(); // TODO Capacity 설정

    /**
     * public
     */
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        CreateDefaultSlot();
    }
    
    public int CurrentIdx
    {
        get => _currentIdx;
        set => _currentIdx = value;
    }

    public List<Slot> SlotList => _slotList;

    public int SlotCount()
    {
        return _slotList.Count;
    }

    // Add 가능 여부에 따른 bool 반환 
    public bool AddSlot(string itemTag)
    {
        Item item = ItemDatabase.Instance.FindItemByName(itemTag);
        
        Slot slot = null;
        foreach (var s in _slotList)
        {
            if (item == s.Item) slot = s;   // 아이템 있는 경우 
        }
        
        if (slot == null) 
        {
            slot = InstantiateSlot(item); // 인벤토리 슬롯 생성 
            slot.Item = item;
            _slotList.Add(slot);
        }
        else 
        {
            if (slot.Item.MaxCount <= slot.ItemCount) return false;
            slot.IncreaseCount();
        }
        return true;
    }
    
    public void SelectOtherSlot(float input)
    {
        if (input > 0 && _currentIdx + 1 < SlotCount())
        {
            _slotList[_currentIdx].ToggleOutline();
            _slotList[++_currentIdx].ToggleOutline();
        }
        else if (input < 0 && _currentIdx - 1 >= 0)
        {
            _slotList[_currentIdx].ToggleOutline();
            _slotList[--_currentIdx].ToggleOutline();
        }
    }
    
    public void ControlItemCount(int index)
    {
        if (index == 0) return; // flashlight는 개수 감소 없음 
        int count = _slotList[index].DecreaseCount();

        if (count == 0) // 슬롯 삭제
        {
            int nextIdx = (index + 1) % SlotCount();
            _slotList[nextIdx].ToggleOutline();
            DeleteSlot(index);

            if (nextIdx == 0) CurrentIdx = nextIdx;
        }
    }
    
    public ItemName GetCurrentSlotItem()
    {
        Slot slot = Inventory.Instance.SlotList[_currentIdx];
        return slot.Item.ItemName;
    }
    
    /**
     * private
     */
    private Slot InstantiateSlot(Item item)
    {
        Debug.Log("InstantiateSlot : " + item.name);
        // 새 슬롯 생성 
        Transform slotGB = Instantiate(itemSlotPrefab, transform).transform;
        
        Image itemImage = slotGB.Find("ItemImage").gameObject.GetComponent<Image>(); 
        Image outlineImage = slotGB.Find("Outline").gameObject.GetComponent<Image>(); 
        Text itemCountText = slotGB.Find("ItemCount").gameObject.GetComponent<Text>();

        Slot newSlot = new Slot(itemImage, outlineImage, itemCountText);
        newSlot.AttachItemImage(item.Sprite);
        
        return newSlot;
    }
    
    private void CreateDefaultSlot()
    {
        // Flashlight 슬롯 생성 
        AddSlot("Flashlight");
        _slotList[0].ToggleOutline();
    }
    
    private void DeleteSlot(int index)
    {
        Destroy(transform.GetChild(index).gameObject);
        _slotList.RemoveAt(index);
    }

}
