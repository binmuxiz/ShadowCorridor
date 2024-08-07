using UnityEngine;

public class Cannedfood 
{
    private static Cannedfood _instance;

    private Cannedfood()
    {
    }

    public static Cannedfood Instance()
    {
        if (_instance == null)
        {
            _instance = new Cannedfood();
        }
        return _instance;
    }
}
