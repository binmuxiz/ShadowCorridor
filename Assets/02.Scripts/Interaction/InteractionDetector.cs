using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    // TODO cam component 부착하기 
    public Camera mainCam;
    public float rayDistance = 5f;

    private void Update()
    {
        DetectInteractableObject();
    }
    
    // 상호작용 가능한 오브젝트는 "열기/닫기", "줍기" 등의 메시지 표시를 한다.
    void DetectInteractableObject()
    {
        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            IInteractable iInteractable = hit.transform.GetComponent<IInteractable>();
            
            if (iInteractable != null)
            {
                Debug.Log("InteractableType : " + iInteractable.GetType());
                iInteractable.ShowMessage();
            }
        }
    }
}
