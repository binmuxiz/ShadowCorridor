using System;
using UnityEngine;

public class Collectable: MonoBehaviour, IInteractable
{
    private const string Message = "줍기";


    public void ShowMessage()
    {
        InteractionUI.Instance.Show(Message);
    }
}
