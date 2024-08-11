using UnityEngine;
using UnityEngine.UI;

public class HandgunController : IUsable
{
    private static HandgunController _instance;
    public GameObject handgun;
    
    
    private HandgunController() {}
    
    public static HandgunController Instance()
    {
        if (_instance == null)
        {
            _instance = new HandgunController();
        }

        return _instance;
    } 
    
    public void Use()
    {
        Debug.Log("Use Handgun");
        Aim();
    }
    
    private void Aim()
    {
        // 조준점 ui 생성, Center ui 제거
        CenterPointUI.Instance.DisableUI();
        AimingPointUI.Instance.EnableUI(); 
        
        // 총 오브젝트 생성 (PLAYER의 자식으로) 
    }
}
