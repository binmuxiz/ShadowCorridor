using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    public Animator ANI;

    public GameObject spider;
    
    public AudioSource openSound;
    public AudioSource closeSound;

    private bool open;

    private bool inReach;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ANI.SetBool("open", false);
        ANI.SetBool("close", false);

        open = false;
        
        spider.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && !open)
        {
            inReach = true;
        }
        else if (other.gameObject.tag == "Reach" && open)
        {
            inReach = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
        }
    }

    void Update()
    {
        if (!open && inReach && Input.GetMouseButtonDown(0))
        {
            openSound.Play();
            ShowSpider();
            ANI.SetBool("open", true);
            ANI.SetBool("close", false);
            open = true;
            inReach = false;
        }
        else if (open && inReach && Input.GetMouseButtonDown(0))
        {
            closeSound.Play();
            ANI.SetBool("open", false);
            ANI.SetBool("close", true);
            open = false;
            inReach = false;
        }
    }

    public void ShowSpider()
    {
        spider.SetActive(true); //거미 활성화
    }
    
}