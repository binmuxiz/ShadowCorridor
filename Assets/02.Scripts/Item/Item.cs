using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField]
    private ItemName _itemName;
    [SerializeField]
    private int _maxCount;
    [SerializeField]
    private Sprite _sprite;

    public ItemName ItemName => _itemName;
    public int MaxCount => _maxCount;
    public Sprite Sprite => _sprite;

    
}
