using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewItem", menuName = "Item/Create New Item ")]
public class Item : ScriptableObject
{
    public string itemName;
    public int maxCount;
    public Sprite sprite;
}
