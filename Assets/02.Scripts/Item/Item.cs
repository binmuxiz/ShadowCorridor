
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
}
