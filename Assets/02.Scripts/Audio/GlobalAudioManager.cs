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
            s.source.name = s.name;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string soundName)
    {
        Array.Find(sounds, item => item.name == soundName).source.Play();
    }
    public void Stop(string soundName)
    {
        Array.Find(sounds, item => item.name == soundName).source.Stop();
    }
}