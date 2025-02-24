using UnityEngine;

public class LeftClickInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float rayDistance = 3f;
    private int _layerMask;

    
    private void Start()
    {
        _layerMask = LayerMask.GetMask("Interactable");
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
            RaycastHit hit;

            Debug.Log("좌클릭");
                
            // 세번쨰 매개값 : raycast의 최대거리. 기본적으로는 무한대로 설정됨
            if (Physics.Raycast(ray, out hit, rayDistance, _layerMask))
            {
                IInteractable iInteractable = hit.transform.GetComponent<IInteractable>();
                Debug.Log(iInteractable);
                
                if (iInteractable != null)
                {
                    iInteractable.Interact();
                }
            }
        }
    }
}
