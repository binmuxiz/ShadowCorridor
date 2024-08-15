using UnityEngine;

public class Box : MonoBehaviour, IInteractable
{
    public Animator ANI;

    public GameObject spider;
    
    public AudioSource openSound;
    public AudioSource closeSound;
    public float activationChance = 0.5f; // 50% 확률로 활성화
    private bool open;

    private const string Message = "열기/닫기";
    
    void Start()
    {
        ANI.SetBool("open", false);
        ANI.SetBool("close", false);

        open = false;
        
        spider.SetActive(false);
    }
    
        
    public void ShowMessage()
    {
        InteractionUI.Instance.Show(Message);
    }

    public void Interact()
    {
        Debug.Log("Box.Interact()");
        
        if (!open)
        {
            openSound.Play();
            ShowSpider();
            ANI.SetBool("open", true);
            ANI.SetBool("close", false);
            open = true;
        }
        else 
        {
            closeSound.Play();
            ANI.SetBool("open", false);
            ANI.SetBool("close", true);
            open = false;
        }
    }
    
    public void ShowSpider()
    {
        if (Random.value < activationChance)
        {
            spider.SetActive(true); // 일정 확률로 거미 활성화
            GlobalAudioManager.Instance.Play(GlobalAudioName.Spider);
        }
    }
}
