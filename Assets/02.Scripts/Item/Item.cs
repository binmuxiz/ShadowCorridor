using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string itemName;
    public int maxCount;
    public GameObject prefab;
    public Sprite image;

    public Item(string itemName, int maxCount, GameObject prefab, Sprite image)
    {
        this.itemName = itemName;
        this.maxCount = maxCount;
        this.prefab = prefab;
        this.image = image;
    }
}
