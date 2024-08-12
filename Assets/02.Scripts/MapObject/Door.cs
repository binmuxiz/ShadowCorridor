using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool lockedDoor = false; // 잠겨있었던 문인지  
    public bool unlocked = false; // 잠겨있었던 문이 잠금해제 되었는지. 
    
    public bool open = false;
    public float openAngle = -90f;
    public float closedAngle = 0f;
    public float smoot = 2f;

    public AudioSource openSound;
    public AudioSource closeSound;
    
    private const string Message = "열기/닫기";
    private const string LockedMessage = "열기/닫기\n잠겨 있다";
    private const string UnLockedMessage = "열기/닫기\n잠금을 풀었다";

    // IInteractable ShowMessage() 구현 
    public void ShowMessage()
    {
        if (lockedDoor) // 잠긴 문 
        {
            if (unlocked) // 잠겼던 문이 잠금해제 되었다 
            {
                InteractionUI.Instance.Show(UnLockedMessage);
            }
            else // 잠긴 문이 잠금해제 되지 않았다 
            {
                InteractionUI.Instance.Show(LockedMessage);
            }
        }
        else // 잠기지 않은 문 
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
        if (lockedDoor && !unlocked) return;
        
        open = !open;

        if (open)
        {
            openSound.Play();
        }
        else
        {
            closeSound.Play();
        }
        if (lockedDoor && unlocked) lockedDoor = false;
    }
    
    public bool Unlock()
    {
        if (lockedDoor && !unlocked)
        {
            unlocked = true;
            return true;
        }
        return false;
    }

    private void FixedUpdate()
    {
        if (!unlocked) return;
        
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
