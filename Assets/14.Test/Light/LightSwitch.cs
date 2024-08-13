using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{

    public GameObject light;
    public AudioSource audio;
    
    private bool _isOn;

    private static string Message = "끄기/켜기";
    
    void Start()
    {
        _isOn = false;
        light.SetActive(false);
    }

    public void ShowMessage()
    {
        InteractionUI.Instance.Show(Message);
    }

    public void Interact()
    {
        if (_isOn) // 켜져 있었던 경우 끈다
        {
            _isOn = false;
            light.SetActive(false);
            audio.Play();
            
        } 
        else // 꺼져 있었던 경우 켠다 
        {
            _isOn = true;
            light.SetActive(true);
            audio.Play();
        }

    }

    public bool IsOn => _isOn;

    public void ToggleLight()
    {
        _isOn = !_isOn;
    }
}
