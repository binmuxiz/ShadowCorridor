using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool open;
    public float openAngle;
    public float closedAngle;
    public float smoot = 2f;
    
    private const string Message = "열기/닫기";

    // IInteractable ShowMessage() 구현 
    public void ShowMessage()
    {
        if (!open) 
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
