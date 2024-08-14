using UnityEngine;

[System.Serializable]
public class Sound {

    public GlobalAudioName name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;

    [Range(-3f, 3f)]
    public float pitch = 1;

    public bool loop = false;

    public bool playOnAwake = false;

    [HideInInspector]
    public AudioSource source;
}

[System.Serializable]
public class SoundEx : Sound
{
    [Range(-3f, 3f)]
    public float spatialBlend = 0f;
}