using UnityEngine;

public class Flashlight {
    
    private static Flashlight _flashlight;
    private Light _light;

    private Flashlight(Light light)
    {
        _light = light;
    }

    public static Flashlight GetInstance()
    {
        if (_flashlight == null)
        {
            _flashlight = new Flashlight(GameObject.FindWithTag("Light").GetComponent<Light>());
        }
        return _flashlight;
    }

    public void ToggleLight()
    {
        if (_light.enabled)
        {
            _light.enabled = false;
        }
        else
        {
            _light.enabled = true;
        }
    }
}
