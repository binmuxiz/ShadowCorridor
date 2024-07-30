
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField]
    private string name;
    private int maxCount;

    public Item(string name, int maxCount)
    {
        this.name = name;
        this.maxCount = maxCount;
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
