using UnityEngine;

public class InventoryItemSelector: MonoBehaviour
{
    private void Update()
    {
        if (Inventory.Instance.SlotCount() == 1) return;
        
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput == 0) return;

        if (Inventory.Instance.GetCurrentSlotItemName() == ItemName.Gun)
        {
            Handgun.Instance.Cancel();
        } 
        Inventory.Instance.SelectOtherSlot(wheelInput);
    }
}
