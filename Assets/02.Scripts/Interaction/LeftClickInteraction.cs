using UnityEngine;

public class LeftClickInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float rayDistance = 5f;
    
    // public ItemDatabase itemDatabase;
    // public Inventory inventory;
    //
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Interaction();
        }
    }
    
    void Interaction()
    {
        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        RaycastHit hit;

        // 세번쨰 매개값 : raycast의 최대거리. 기본적으로는 무한대로 설정됨
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            IInteractable iInteractable = hit.transform.GetComponent<IInteractable>();

            if (iInteractable != null)
            {
                iInteractable.Interact();
            }
        }
    }
}
