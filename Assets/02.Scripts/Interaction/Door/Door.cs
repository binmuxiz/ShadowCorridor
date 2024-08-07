using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Door : MonoBehaviour, IInteractable
{
    public bool isLocked;
    public bool open;
    public float openAngle;
    public float closedAngle;
    public float smoot = 2f;
    
    public InteractionUI interactionUI;
    public Text lockedDoorText;

    public void ChangeDoorState()
    {
        open = !open;
    }

    private void Update()
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, closedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }
    }


    public void Interact()
    {
        
    }

    public void ShowMessage()
    {
         
        // if (isClosed) 
        // {
        //      interactionUI.Show("열기/닫기"); 
        // }
    }

    public void HideMessage()
    {
        interactionUI.Hide();
    }
}
