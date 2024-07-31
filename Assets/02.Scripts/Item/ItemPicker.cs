using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public Inventory inventory;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.transform.gameObject;
                Debug.Log("ClickedObject : " + clickedObject.name);
                
                Item item = itemDatabase.FindItemByName(clickedObject.name);
                // Item을 찾은 경우 
                if (item) 
                {
                    Debug.Log(item.name);
                    inventory.AddItem(item);
                }
                else
                {
                    Debug.Log("Item Not Found");
                }
                Destroy(clickedObject);
            }
        }
    }
}
