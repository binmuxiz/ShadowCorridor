using System;
using UnityEngine;

public class RightClickInteraction : MonoBehaviour
{
    // private void Update()
    // {
    //     // TODO 총은 우클릭 조준 후, 좌클릭 격발 
    //     if (Input.GetMouseButtonDown(1)) // 우클릭 
    //     {
    //         // TODO 아이템 사용
    //         int currentIdx = Inventory.Instance.CurrentIdx;
    //
    //         UseItem(currentIdx);
    //
    //         if (currentIdx == 0) return; // 손전등은 개수 감소 x
    //         ControlItemCount(currentIdx);
    //     }
    // }
    //
    // private void UseItem(int index)
    // {
    //     Slot slot = Inventory.Instance.SlotList[index];
    //     ItemName name = slot.Item.ItemName;
    //
    // }
    //
    // private void ControlItemCount(int index)
    // {
    //     int count = inventory.SlotList[index].DecreaseCount();
    //
    //     if (count == 0) // 아이템 개수가 0이 되면 슬롯 삭제 
    //     {
    //         int nextIndex = (index + 1) % inventory.SlotCount();
    //         inventory.SlotList[nextIndex].ToggleOutline();
    //         inventory.DeleteSlot(index);
    //
    //         if (nextIndex == 0)
    //         {
    //             inventory.CurrentIdx = nextIndex;
    //         }
    //     }
    // }
    //

}
