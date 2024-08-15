using UnityEngine;

public class Collectable: MonoBehaviour, IInteractable
{
    private const string Message = "줍기";

    public void ShowMessage()
    {
        InteractionUI.Instance.Show(Message);
    }

    public void Interact()
    {
        if (PickUp())
        {
            if (gameObject.CompareTag("Firstaid"))
            {
                GlobalAudioManager.Instance.Play(GlobalAudioName.FirstAidPickUp);
            }
            else
            {
                GlobalAudioManager.Instance.Play(GlobalAudioName.ItemPickUp);
            }
            Destroy(gameObject);    
        }
    }
    
    public bool PickUp()
    {
        if (gameObject.CompareTag("Firstaid"))
        {
            return Firstaid.Instance.IncreaseCount();
        }
        return Inventory.Instance.AddSlot(gameObject.tag);
    }
}
