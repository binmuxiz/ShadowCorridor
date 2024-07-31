using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public Item item;
    public int count;

    public InventoryItem(Item item)
    {
        this.item = item;
        this.count = 1;
    }
}

