using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    public List<GameObject> prefabs;

    void Start()
    {
        items.Add(new Item("FlashLight", 1, prefabs[0]));
        items.Add(new Item("Key", -1, prefabs[1]));
    }

    public Item GetItemByName(string name)
    {
        return items.Find(item => item.name == name);
    }
}


