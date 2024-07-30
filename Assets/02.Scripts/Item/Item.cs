using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int maxCount;
    public GameObject prefab;
    public Sprite image;

    public Item(string name, int maxCount, GameObject prefab, Sprite image)
    {
        this.name = name;
        this.maxCount = maxCount;
        this.prefab = prefab;
        this.image = image;
    }
}
