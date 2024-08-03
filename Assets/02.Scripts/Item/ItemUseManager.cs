using UnityEngine;

public class ItemUseManager : MonoBehaviour
{
    public Inventory inventory;
    public ItemSelector itemSelector;

    private void Update()
    {
        // TODO 총은 우클릭 조준 후, 좌클릭 격발 
        if (Input.GetMouseButtonDown(1)) // 우클릭 
        {
            // TODO 아이템 사용
            
            int currentIdx = itemSelector.CurrentIdx;
            int count = inventory.SlotList[currentIdx].DecreaseCount();

            if (count == 0)
            {
                inventory.DeleteSlot(currentIdx);
            }

            // Slot 삭제 시 그 다음의 Slot select, 마지막 슬롯 삭제 시 마지막 슬롯 select
            if (currentIdx != 0)
            {
                itemSelector.SelectSlot();
            }
        }
    }
}
