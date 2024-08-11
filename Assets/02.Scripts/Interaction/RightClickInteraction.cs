using System.Collections.Generic;
using UnityEngine;

public class RightClickInteraction : MonoBehaviour
{
    private Dictionary<ItemName, IUsable> usableItemDict = new Dictionary<ItemName, IUsable>();


    private void Start()
    {
        usableItemDict.Add(ItemName.Flashlight, Flashlight.Instance());
        usableItemDict.Add(ItemName.Gun, HandgunController.Instance());
        usableItemDict.Add(ItemName.CannedFood, Cannedfood.Instance());
        usableItemDict.Add(ItemName.RustKey, Rustkey.Instance());
    }

    private void Update()
    {
        // 우클릭 시 인벤토리에 초점이 맞춰진 아이템 사용 
        if (Input.GetMouseButtonDown(1)) 
        {
            int currentIdx = Inventory.Instance.CurrentIdx;
            IUsable item = GetItem(currentIdx);
            
            if (item is Rustkey  && !IsLockedDoorClicked()) return;
            
            item.Use();
            Inventory.Instance.ControlItemCount(currentIdx);
        }
    }

    private IUsable GetItem(int index)
    {
        Slot slot = Inventory.Instance.SlotList[index];
        ItemName name = slot.Item.ItemName;
        return usableItemDict[name];
    }
    
    private bool IsLockedDoorClicked()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Door door = hit.transform.GetComponent<Door>();

            if (door != null) // 열쇠를 문을 향해 사용한 경우 
            {
                if (door.Unlock()) return true;
            }
        }
        return false;
    }
}
