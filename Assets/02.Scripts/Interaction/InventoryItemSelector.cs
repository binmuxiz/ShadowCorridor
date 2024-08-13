using UnityEngine;

public class InventoryItemSelector: MonoBehaviour
{
    private void Update()
    {
        // Debug.Log("현재 아이템슬롯 개수 : " + SlotCount());
        if (Inventory.Instance.SlotCount() == 1) return;
        
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        if (wheelInput != 0)
        {
            int idx = Inventory.Instance.CurrentIdx;
            Slot slot = Inventory.Instance.SlotList[idx];
            if (slot.Item.ItemName == ItemName.Gun)
            {
                Handgun.Instance.Cancel();
            }
        }
        if (wheelInput > 0) Inventory.Instance.SelectRightSlot();
        else if (wheelInput < 0) Inventory.Instance.SelectLeftSlot();
        
    }
}
