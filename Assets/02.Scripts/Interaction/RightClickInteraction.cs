using System.Collections.Generic;
using UnityEngine;

public class RightClickInteraction : MonoBehaviour
{
    private Dictionary<ItemName, IUsable> usableItemDict = new Dictionary<ItemName, IUsable>();


    private void Start()
    {
        usableItemDict.Add(ItemName.Flashlight, Flashlight.Instance());
        usableItemDict.Add(ItemName.Gun, Handgun.Instance);
        usableItemDict.Add(ItemName.CannedFood, Cannedfood.Instance());
        usableItemDict.Add(ItemName.RustKey, Rustkey.Instance());
    }

    private void Update()
    {
        // 우클릭 시 인벤토리에 초점이 맞춰진 아이템 사용 
        if (Input.GetMouseButtonDown(1)) 
        {
            int idx = Inventory.Instance.CurrentIdx;

            if (GetItem(idx).Use())
            {
                Inventory.Instance.ControlItemCount(idx);
            }
        }
    }

    private IUsable GetItem(int index)
    {
        Slot slot = Inventory.Instance.SlotList[index];
        ItemName name = slot.Item.ItemName;
        return usableItemDict[name];
    }
}
