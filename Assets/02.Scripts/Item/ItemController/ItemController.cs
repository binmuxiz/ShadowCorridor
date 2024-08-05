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
            
            
            if (currentIdx == 0) return; // 손전등은 개수 감소 x
            ControlItemCount(currentIdx);
        }
    }
    
    private void ControlItemCount(int index)
    {
        int count = inventory.SlotList[index].DecreaseCount();

        if (count == 0)
        {
            int nextIndex = (index + 1) % inventory.SlotCount();
            inventory.SlotList[nextIndex].ToggleOutline();
            inventory.DeleteSlot(index);
            inventory.CurrentIdx = nextIndex;
            
        }
    }
}
