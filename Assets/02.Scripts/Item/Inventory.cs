using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject itemSlotPrefab;


    public void Start()
    {
        Debug.Log("Inventory Script Start");
        Instantiate(itemSlotPrefab, transform);
    }
}
