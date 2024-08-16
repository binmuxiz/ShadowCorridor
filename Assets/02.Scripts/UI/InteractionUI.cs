using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;
    public TextMeshProUGUI interactionText;

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
