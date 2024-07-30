
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items;

    void Start()
    {
        // 아이템 데이터베이스 초기화
        items = new List<Item>
        {
            // new Item("FlashLight", 99, flashLightPrefab, flashLightImage)
        };
    }
}
