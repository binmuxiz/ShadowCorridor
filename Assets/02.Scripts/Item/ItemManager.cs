using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Inventory inventory;
    public ItemDatabase itemDatabase;
    public InventoryUI inventoryUI;

    // private void Start()
    // {
    //     // inventory = GetComponent<Inventory>();
    //     // itemDatabase = GetComponent<ItemDatabase>();
    //
    //     if (itemDatabase == null)
    //     {
    //         Debug.Log("ItemDatabase 초기화 안됨");
    //     }
    //     
    // }

    private void Awake()
    {
        // 필드가 Inspector에서 올바르게 연결되었는지 확인
        if (inventory == null)
        {
            Debug.LogError("Inventory 초기화 안됨");
        }

        if (itemDatabase == null)
        {
            Debug.LogError("ItemDatabase 초기화 안됨");
        }

        if (inventoryUI == null)
        {
            Debug.LogError("InventoryUI 초기화 안됨");
        }
    }
    void Update()
    {
        // 아이템 좌클릭시
        if (Input.GetMouseButtonDown(0))
        {
            /***
             * Camera.main -> 메인 카메라
             * 이 스크립트를 Main Camera 오브젝트에 부착하면 메인 카메라와 관련된 스크립트를 관리하기 유용
             * 이 스크립트를 다른 빈 게임 오브젝트에 부착하면 스크립트가 카메라와 별도로 존재
             * 이는 스크립트를 분리하고 싶을 때 유용하다
             * 여러 카메라를 사용하거나 특정 카메라를 선택하는 등 더 많은 유연성을 제공 
             */
            /***
             * 클릭할 수 있는 모든 게임 오브젝트에 Collider를 추가해야
             * Collider가 없다면 RayCast는 물체를 인지하지 못한다. 
             */
            
            // 1. 카메라에서 클릭한 위치로 RayCast 생성
            // 현재 마우스 위치(Input.mousePosition)으로부터 시작하는 Ray를 생성
            // Ray는 카메라의 화면 공간에서 월드 공간으로의 방향
            // hit : 충돌된 물체에 대한 정보를 저장하는 변수 
            // out 키워드를 사용하여 이 변수가 함수 내부에서 설정된다는 것을 나타낸다.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            // PHysics.Raycast() : 생성된 Ray가 콜라이더와 충돌하는지 확인
            if (Physics.Raycast(ray, out hit))
            {
                string name = hit.transform.name;
                Destroy(hit.transform.gameObject);
                Debug.Log("클릭한 ITEM : " + name);
                
                // TODO Item을 찾지 못한 경우 예외처리 
                Item item = itemDatabase.GetItemByName(name);
                // item을 찾지 못한 경우 
                if (item == null)
                {
                    Debug.Log($"Cannot found {name}");                        
                }
                else
                {
                    inventory.AddItem(item);
                }
                // inventory.PrintInventoryItems();
            }
        }       
    }
}
