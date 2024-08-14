using System;
using UnityEngine;

public class GlobalAudioManager : MonoBehaviour {

    public static GlobalAudioManager Instance;

    public Sound[] sounds ;

    void Awake ()
    {
        Instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.name = s.name.ToString();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    public void Play(GlobalAudioName audioName)
    {
        Array.Find(sounds, item => item.name == audioName).source.Play();
    }
    public void Stop(GlobalAudioName audioName)
    {
        Array.Find(sounds, item => item.name == audioName).source.Stop();
    }
}