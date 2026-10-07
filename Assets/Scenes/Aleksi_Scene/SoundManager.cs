using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    public List<AudioClip> sounds = new List<AudioClip>();
    public AudioSource audioSource;
    public AudioClip bgMusic;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgMusic;
        audioSource.Play();
    }
    public void PlaySound(string clipName)
    {
        foreach (AudioClip clip in sounds)
            if (clip.name == clipName)
                audioSource.PlayOneShot(clip);
    }
    public void GameEnd(string clipName)
    {
        audioSource.Stop();
        foreach (AudioClip clip in sounds)
            if (clip.name == clipName)
                audioSource.PlayOneShot(clip);
    }
}


