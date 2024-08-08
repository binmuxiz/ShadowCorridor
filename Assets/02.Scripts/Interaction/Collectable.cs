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
            Destroy(gameObject);    
        }
    }
    
    public bool PickUp()
    {
        if (gameObject.CompareTag("Firstaid"))
        {
            return FirstaidCountUI.Instance.IncreaseCount();
        }
        return Inventory.Instance.AddSlot(gameObject.tag);
    }
}
