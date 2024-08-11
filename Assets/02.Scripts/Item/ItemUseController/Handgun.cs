using System;
using UnityEngine;

public class Handgun : MonoBehaviour, IUsable
{
    public static Handgun Instance;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    
    public void Use()
    {
        Aim();
    }
    
    private void Aim()
    {
        // 조준점 ui 생성, Center ui 제거
        CenterPointUI.Instance.DisableUI();
        AimingPointUI.Instance.EnableUI(); 
        
        gameObject.SetActive(true);
        
    }
}
