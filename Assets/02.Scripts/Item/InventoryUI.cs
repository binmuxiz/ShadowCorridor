using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject ItemUIPrefab;
    
    void Awake()
    {
        Debug.LogError("ItemUIPrefab" + ItemUIPrefab);
    }

    public void AddItemUI(InventoryItem inventoryItem)
    {
        GameObject itemUI = Instantiate(ItemUIPrefab);
        // itemUI 자식 오브젝트 : ItemImage : Image Component의 Source Image 속성 
        //                      ItemCount : Text 변경 

        Debug.Log(itemUI.transform.childCount);
        // GameObject itemImage = itemUI.transform.GetChild(0).gameObject;
        // GameObject itemCount = itemUI.transform.GetChild(1).gameObject;

    }
}
