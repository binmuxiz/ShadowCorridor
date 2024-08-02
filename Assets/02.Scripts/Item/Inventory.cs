// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
//
// public class Inventory : MonoBehaviour
// {
//     private Dictionary<string, InventoryItem> inventoryItems = new Dictionary<string, InventoryItem>();
//     public GameObject itemSlotPrefab;
//
//     public void AddItem(Item item)
//     {
//         if (!inventoryItems.ContainsKey(item.itemName))
//         {
//             instantiateItem(item);
//         }
//         else
//         {
//             InventoryItem inventoryItem = inventoryItems[item.itemName];
//             if (inventoryItem.count >= item.maxCount)
//             {
//                 // TODO 아이템 획득 불가 
//             }
//             else
//             {
//                 inventoryItem.count++;
//                 Debug.Log(item.name + ": " + inventoryItem.count);
//                 // UI Text 변경 
//             }
//         }
//     }
//
//     private void instantiateItem(Item item)
//     {
//         InventoryItem inventoryItem = new InventoryItem(item);
//         inventoryItems.Add(item.itemName, inventoryItem);
//             
//         // 새 슬롯 생성 
//         GameObject slot = Instantiate(itemSlotPrefab, transform);
//
//         // 이미지 변경 
//         // Slot의 자식 오브젝트 : ItemImage의 Image 컴포넌트
//         Image image = slot.transform.Find("ItemImage").gameObject.GetComponent<Image>(); 
//         image.sprite = item.sprite;
//     }
// }
