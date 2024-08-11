using UnityEngine;
using UnityEngine.UI;

public class AimingPointUI : MonoBehaviour
{
    public static AimingPointUI Instance;
    private RawImage image;

    private void Awake()
    {
        Instance = this;
        image = gameObject.GetComponent<RawImage>();
        image.enabled = false;
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
