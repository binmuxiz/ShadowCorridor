using System;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public Inventory inventory;
    private int currentIdx = 0;
    
    private void Update()
    {
        Debug.Log("현재 아이템슬롯 개수 : " + inventory.SlotCount());
        if (inventory.SlotCount() == 1) return;
        
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        
        // 휠을 올렸을 때 : 오른쪽 아이템 선택                                 
        if (wheelInput > 0)
        {
            Debug.Log("MouseUp : " + wheelInput);

            if (currentIdx + 1 < inventory.SlotCount())
            {
                inventory.SlotList[currentIdx].ToggleOutline();
                inventory.SlotList[++currentIdx].ToggleOutline();
            }
        }
        // 휠을 내렸을 때 : 왼쪽 아이템 선택 
        else if (wheelInput < 0)
        {
            Debug.Log("MouseDown : " + wheelInput);
            
            if (currentIdx - 1 >= 0)
            {
                inventory.SlotList[currentIdx].ToggleOutline();
                inventory.SlotList[--currentIdx].ToggleOutline();
            }
        }
    }
}
