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
}
