using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public Item FindItemByName(string itemName)
    {
        try
        {
            foreach (Item item in items)
            {
                // TODO Equals, ==, CompareTo 비교 
                if (EnumUtil<ItemName>.StringToEnum(itemName) == item.ItemName)
                {
                    return item;
                }
            }

        }
        catch (ArgumentException e)
        {
            Debug.Log(e.Message);
        }

        return null;
    }
}
