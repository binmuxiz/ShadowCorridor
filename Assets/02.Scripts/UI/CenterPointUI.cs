using UnityEngine;
using UnityEngine.UI;

public class CenterPointUI : MonoBehaviour
{
    public static CenterPointUI Instance;
    private RawImage image;

    private void Awake()
    {
        Instance = this;
        image = gameObject.GetComponent<RawImage>();
        image.enabled = true;
    }
    
    
    public void EnableUI()
    {
        image.enabled = true;
    }
    
    public void DisableUI()
    {
        image.enabled = false;
    }
}
