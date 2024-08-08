using UnityEngine;

public class Rustkey : IUsable
{
    private static Rustkey _instance;

    private Rustkey()
    {
        
    }
    
    public static Rustkey Instance()
    {
        if (_instance == null)
        {
            _instance = new Rustkey();
        }
        return _instance;
    }
    
    public void Use()
    {
        Debug.Log("Use RustKey");
        
        
    }
}
