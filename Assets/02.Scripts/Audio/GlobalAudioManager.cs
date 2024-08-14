using System;
using System.Reflection;
using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    public static GlobalAudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Play(GlobalAudioName name)
    {
        Debug.Log(this.GetType().Name + ": " + MethodBase.GetCurrentMethod().Name);
        
        // todo 예외처리 
        // GlobalAudioManager 게임오브젝트의 자식 오브젝트를 이륾으로 가져온다. 
        GameObject audioGO = gameObject.transform.Find(name.ToString()).gameObject;
        audioGO.GetComponent<AudioSource>().Play();
    }
    
    public void Stop(GlobalAudioName name)
    {
        Debug.Log(this.GetType().Name + ": " + MethodBase.GetCurrentMethod().Name);
        
        GameObject audioGO = gameObject.transform.Find(name.ToString()).gameObject;
        audioGO.GetComponent<AudioSource>().Stop();
    }
}
