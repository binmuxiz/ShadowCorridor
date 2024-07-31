
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    public string itemName;
    public int itemCount;

    public void AddCount()
    {
        itemCount++;
    }
}
