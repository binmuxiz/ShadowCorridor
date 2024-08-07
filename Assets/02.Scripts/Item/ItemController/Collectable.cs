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
        // Item item = itemDatabase.FindItemByName(gameObject.tag);
        //     
        // if (item) 
        // {
        //     bool isAdded = inventory.AddSlot(item);
        //     if (isAdded) Destroy(gameObject);
        // }
    }
}
