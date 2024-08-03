using System;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public Inventory inventory;
    private int _currentIdx = 0;

    public int CurrentIdx => _currentIdx;
    
    private void Update()
    {
        Debug.Log("현재 아이템슬롯 개수 : " + inventory.SlotCount());
        if (inventory.SlotCount() == 1) return;
        
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        
        // 휠을 올렸을 때 : 오른쪽 아이템 선택                                 
        if (wheelInput > 0)
        {
            Debug.Log("MouseUp : " + wheelInput);

            if (_currentIdx + 1 < inventory.SlotCount())
            {
                inventory.SlotList[_currentIdx].ToggleOutline();
                inventory.SlotList[++_currentIdx].ToggleOutline();
            }
        }
        // 휠을 내렸을 때 : 왼쪽 아이템 선택 
        else if (wheelInput < 0)
        {
            Debug.Log("MouseDown : " + wheelInput);
            
            if (_currentIdx - 1 >= 0)
            {
                inventory.SlotList[_currentIdx].ToggleOutline();
                inventory.SlotList[--_currentIdx].ToggleOutline();
            }
        }
    }
    
    public void SelectSlot()
    {
        
    }
}
