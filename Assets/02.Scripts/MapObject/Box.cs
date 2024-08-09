using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    private const string Message = "열기/닫기";
        
    public void ShowMessage()
    {
        InteractionUI.Instance.Show(Message);
    }

    public void Interact()
    {
        
    }
}
