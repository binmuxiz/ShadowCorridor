using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    public Animator ANI;

    public GameObject openText;
    public GameObject closedText;

    public GameObject spider;
    
    public AudioSource openSound;
    public AudioSource closeSound;

    private bool open;

    private bool inReach;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openText.SetActive(false);
        closedText.SetActive(false);
        
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
            openText.SetActive(true);
        }
        else if (other.gameObject.tag == "Reach" && open)
        {
            inReach = true;
            closedText.SetActive(true);
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            closedText.SetActive(false);
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
            openText.SetActive(false);
            inReach = false;
        }
        else if (open && inReach && Input.GetMouseButtonDown(0))
        {
            closeSound.Play();
            ANI.SetBool("open", false);
            ANI.SetBool("close", true);
            open = false;
            closedText.SetActive(false);
            inReach = false;
        }
    }

    public void ShowSpider()
    {
        spider.SetActive(true); //거미 활성화
    }
    
}