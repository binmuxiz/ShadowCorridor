
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
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
