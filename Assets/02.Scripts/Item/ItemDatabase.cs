using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/**
 * Serializable
 * 해당 타입을 직렬화 가능하도록 만든다.
 * 직렬화를 이용하여 게임을 종류한 이후에도 이전 상태를 보존할 수 있다.
 */
[System.Serializable]
public class ItemDescription 
{
    public string name;
    public Texture2D image; 
}

public class InventoryItem
{
    public ItemDescription Item;
    public int Count;

    // 
    public bool IsEmpty => this == Empty;

    public const int MaxCount = 8;
    // TODO readonly
    public static readonly InventoryItem Empty = new InventoryItem();
    
}

// ScriptableObject 
// 에셋 메뉴 생성 UnityEngine의 sealed Class
[CreateAssetMenu(menuName = "Inventory/Items")]
public class ItemDatabase : ScriptableObject
{
    /**
     * SerializableField
     *
     * 해당 필드를 Inspector창에서 직렬화되도록 지정 
     * private을 유지하며 inspector창에서 수정 가능
     */
    [SerializeField] 
    private List<ItemDescription> items = new List<ItemDescription>();

    public List<InventoryItem> GetRandomItems(int count)
    {
        List<InventoryItem> toRet = new List<InventoryItem>();
        for (int i = 0; i < count; i++)
        {
            
            if (Random.Range(0, 1f) > .5f)
            {
                toRet.Add(new InventoryItem()
                {
                    Item = items[Random.Range(0, items.Count)],
                    Count = Random.Range(1, InventoryItem.MaxCount)
                });
                
            }
        }
        return toRet;
    }
    
        
}
