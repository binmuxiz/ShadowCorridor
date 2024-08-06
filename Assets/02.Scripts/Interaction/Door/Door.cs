using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour, IInteractable
{
    public bool isLocked;
    public bool isClosed;
    
    public InteractionUI interactionUI;
    public Text lockedDoorText; 
    
    public void Interact()
    {
        Debug.Log("문 열기/닫기");
        
        // Debug.Log("인스턴스ID : " + GetInstanceID());
        
        // 잠겨 있는 경우 
        if (isLocked)
        {
            isLocked = true;
            
        }
        // 잠겨 있지 않은 경우 
        else
        {
            
        }
        
    }

    public void ShowMessage()
    {
         
        if (isClosed) 
        {
             interactionUI.Show("열기/닫기"); 
        }
    }

    public void HideMessage()
    {
        interactionUI.Hide();
    }
}
