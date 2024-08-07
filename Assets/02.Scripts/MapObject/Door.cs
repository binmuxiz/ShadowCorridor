using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool locked = false;
    public bool open = false;
    public float openAngle = -90f;
    public float closedAngle = 0f;
    public float smoot = 2f;
    
    private const string Message = "열기/닫기";
    private const string LockedMessage = "잠겨 있다";
    private const string UnLockedMessage = "잠금을 풀었다";

    // IInteractable ShowMessage() 구현 
    public void ShowMessage()
    {
        if (!open && locked) 
        {
             InteractionUI.Instance.Show(Message + "\n" + LockedMessage); 
        }
        else
        {
             InteractionUI.Instance.Show(Message); 
        }
    }

    public void Interact()
    {
        
        ChangeDoorState();
    }

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
}
