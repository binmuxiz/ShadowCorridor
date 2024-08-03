using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public Inventory inventory;

    private const string _DEFAULT_ITEM = "Flashlight";

    private void Start()
    {
        // 초기 아이템 (손전등) 
        Item item = itemDatabase.FindItemByName(_DEFAULT_ITEM);
        inventory.InstantiateSlot(item);
    }

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
                
                // 각 GameObject의 이름이 아닌 Tag로 찾기
                Item item = null;
                
                if (clickedObject.tag != null)
                    item = itemDatabase.FindItemByName(clickedObject.tag);
                
                if (item) 
                {
                    Debug.Log("Find " + item.name);
                    bool isAdded = inventory.Add(item);
                    if (isAdded) Destroy(clickedObject);
                }
            }
        }
    }
    
}
