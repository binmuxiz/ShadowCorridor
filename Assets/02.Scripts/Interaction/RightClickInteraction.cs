using System.Collections.Generic;
using UnityEngine;

public class RightClickInteraction : MonoBehaviour
{
    private Dictionary<ItemName, IUsable> usableItemDict = new Dictionary<ItemName, IUsable>();


    private void Start()
    {
        usableItemDict.Add(ItemName.Flashlight, Flashlight.Instance());
        usableItemDict.Add(ItemName.Gun, Handgun.Instance());
        usableItemDict.Add(ItemName.CannedFood, Cannedfood.Instance());
        usableItemDict.Add(ItemName.RustKey, Rustkey.Instance());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 우클릭 
        {
            int currentIdx = Inventory.Instance.CurrentIdx;
            UseItem(currentIdx);
            Inventory.Instance.ControlItemCount(currentIdx);
        }
    }
    
    private void UseItem(int index)
    {
        Slot slot = Inventory.Instance.SlotList[index];
        ItemName name = slot.Item.ItemName;
        usableItemDict[name].Use();
    }
}
