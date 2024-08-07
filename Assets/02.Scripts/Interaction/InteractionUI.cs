using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    public Text interactionText;
    public static InteractionUI Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Show(string message)
    {
        interactionText.text = message;
        interactionText.enabled = true;
    }
    
    public void Hide()
    {
        interactionText.enabled = false;
    }
}
