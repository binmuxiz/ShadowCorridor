using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    public Camera cam;
    public float rayDistance = 5f;
    public InteractionUI InteractionUI;

    private void Update()
    {
        DetectInteractableObject();
    }
    
    void DetectInteractableObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, rayDistance))
        {
            // Debug.Log(raycastHit.transform.gameObject.name);
            
            IInteractable interactable = raycastHit.transform.GetComponent<IInteractable>();
            
            if (interactable != null)
            {
                // Debug.Log("InteractableType : " + interactable.GetType());
                InteractionUI.Show("열기/닫기");
                interactable.Interact();
            }
            else
            {
                InteractionUI.Hide();
            }
        }
        else
        {
            InteractionUI.Hide();
        }
    }
}
