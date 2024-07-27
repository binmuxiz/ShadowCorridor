using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    void Start()
    {
        items.Add(new Item("Apple", 1));
        items.Add(new Item("Grape", 2));
    }

    public Item GetItemByName(string name)
    {
        return items.Find(item => item.name == name);
    }
}


