using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public Inventory inventory;

    private const string _DEFAULT_ITEM = "Flashlight";

    private void Start()
    {
        // 초기 아이템 (손전등) 
        Item item = itemDatabase.FindItemByName(_DEFAULT_ITEM);
        inventory.AddSlot(item);
        inventory.SlotList[0].ToggleOutline(); // 손전등은 처음에 outline = true
    }
}
