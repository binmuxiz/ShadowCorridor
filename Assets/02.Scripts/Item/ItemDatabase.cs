
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    // Item은 Inspector에서 설정 
    public List<Item> items = new List<Item>();
    
    

    public Item FindItemByName(string name)
    {
        foreach (Item item in items)
        {
            if (name == item.itemName)
            {
                return item;
            }
        }

        return null;
    }
}
