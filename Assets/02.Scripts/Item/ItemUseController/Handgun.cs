using UnityEngine;

public class Handgun : IUsable
{
    private static Handgun _instance;
    
    private Handgun() {}
    
    public static Handgun Instance()
    {
        if (_instance == null)
        {
            _instance = new Handgun();
        }

        return _instance;
    } 
    
    public void Use()
    {
        Debug.Log("Use Handgun");
        
    }
    
    private void Aim()
    {
        // 조준점 ui 생성
        
        
        // 총 오브젝트 생성 (PLAYER의 자식으로) 
    }
}
