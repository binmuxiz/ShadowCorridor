using System;
using UnityEngine;

public class InventoryItemUI : MonoBehaviour
{
    public GameObject itemUIPrefab;

    private void Start()
    {
        Debug.Log("InventoryItemUI.Start()");
        GameObject itemUI = Instantiate(itemUIPrefab);
        itemUI.transform.SetParent(transform);
    }
}
