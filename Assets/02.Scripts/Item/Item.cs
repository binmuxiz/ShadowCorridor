using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string itemName;
    public int maxCount;
    // public GameObject prefab;
    public Sprite image;

    public Item(string itemName, int maxCount, Sprite image)
    {
        this.itemName = itemName;
        this.maxCount = maxCount;
        this.image = image;
    }

    // public Item(string name, int maxCount, GameObject prefab, Sprite image)
    // {
    //     this.name = name;
    //     this.maxCount = maxCount;
    //     this.prefab = prefab;
    //     this.image = image;
    // }
}
