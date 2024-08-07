using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    // TODO cam component 부착하기 
    public Camera cam;
    public float rayDistance = 5f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.GetComponent<Door>().ChangeDoorState();
                }
            }
        }
        
        // DetectInteractableObject();
    }
    
    void DetectInteractableObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, rayDistance))
        {
            // Debug.Log(raycastHit.transform.gameObject.name);
            
            IInteractable iInteractable = raycastHit.transform.GetComponent<IInteractable>();
            
            if (iInteractable != null)
            {
                Debug.Log("InteractableType : " + iInteractable.GetType());
                iInteractable.ShowMessage();
            }
        }
    }
}
