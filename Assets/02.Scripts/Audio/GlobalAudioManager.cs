using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    public static GlobalAudioManager Instance;
    private Dictionary<GlobalAudioName, AudioSource> _audioDict;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _audioDict = new Dictionary<GlobalAudioName, AudioSource>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            
            GlobalAudioName name = EnumUtil<GlobalAudioName>.StringToEnum(child.name);
            AudioSource value = child.gameObject.GetComponent<AudioSource>();
            _audioDict.Add(name, value);
            
        }
    }

    public void Play(GlobalAudioName audioName)
    {
        AudioSource audioSource = _audioDict[audioName];
        
        if (audioSource)
        {
            audioSource.Play();
        }
    }
    
    public void Stop(GlobalAudioName audioName)
    {
        AudioSource audioSource = _audioDict[audioName];

        if (audioSource)
        {
            audioSource.Stop();
        }
    }
}
