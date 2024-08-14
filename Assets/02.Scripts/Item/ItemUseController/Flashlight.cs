using UnityEngine;

public class Flashlight: IUsable {
    
    private static Flashlight _instance;
    private Light _light;

    private Flashlight(Light light)
    {
        _light = light;
    }

    public static Flashlight Instance()
    {
        if (_instance == null)
        {
            _instance = new Flashlight(GameObject.FindWithTag("Flashlight").GetComponent<Light>());
        }
        return _instance;
    }

    public void Use()
    {
        _light.enabled = !_light.enabled;
        GlobalAudioManager.Instance.Play(GlobalAudioName.FlashLight);
    }
}
