
using UnityEngine;

public class Cannedfood : IUsable
{
    private static Cannedfood _instance;
    private int health = 40;

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

    public void Use()
    {
        GlobalAudioManager.Instance.Play(GlobalAudioName.CannedFood);
        PlayerHealth.Instance.IncreaseHealth(health);
    }
}
