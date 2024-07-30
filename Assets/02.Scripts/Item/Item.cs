
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item 
{

    public string name;
    public int maxCount;
    public GameObject prefab;


    public Item(string name, int maxCount, GameObject prefab)
    {
        this.name = name;
        this.maxCount = maxCount;
        this.prefab = prefab;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int MaxCount
    {
        get => maxCount;
        set => maxCount = value;
    }
}
