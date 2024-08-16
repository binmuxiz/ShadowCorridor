using UnityEngine;

public class Handgun : MonoBehaviour, IUsable
{
    public static Handgun Instance;
    public GameObject centerPointUI;
    public GameObject aimPointUI;
    

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        
        aimPointUI.SetActive(false);
    }
    
    public bool Use()
    {
        // 조준점 ui 생성, Center ui 제거
        gameObject.SetActive(true);
        
        centerPointUI.SetActive(false);
        aimPointUI.SetActive(true);

        return false;
    }
    
    public void Cancel()
    {
        // 조준점 ui 생성, Center ui 제거
        gameObject.SetActive(false);
        
        centerPointUI.SetActive(true);
        aimPointUI.SetActive(false);
    }
}
