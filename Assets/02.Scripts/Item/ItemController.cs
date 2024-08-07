using System;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Inventory inventory;

    private void Update()
    {
        // TODO 총은 우클릭 조준 후, 좌클릭 격발 
        if (Input.GetMouseButtonDown(1)) // 우클릭 
        {
            // TODO 아이템 사용
            int currentIdx = inventory.CurrentIdx;

            UseItem(currentIdx);

            if (currentIdx == 0) return; // 손전등은 개수 감소 x
            ControlItemCount(currentIdx);
        }
    }

    private void UseItem(int index)
    {
        Slot slot = inventory.SlotList[index];
        ItemName name = slot.Item.ItemName;

        switch (name)
        {
            case ItemName.Flashlight:
                Flashlight.GetInstance().ToggleLight();
                break;
            case ItemName.RustKey:
                break;
            case ItemName.Gun:
                break;
            case ItemName.Firstaid:
                break;
            case ItemName.CannedFood:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void ControlItemCount(int index)
    {
        int count = inventory.SlotList[index].DecreaseCount();

        if (count == 0) // 아이템 개수가 0이 되면 슬롯 삭제 
        {
            int nextIndex = (index + 1) % inventory.SlotCount();
            inventory.SlotList[nextIndex].ToggleOutline();
            inventory.DeleteSlot(index);

            if (nextIndex == 0)
            {
                inventory.CurrentIdx = nextIndex;
            }
        }
    }
    

}
