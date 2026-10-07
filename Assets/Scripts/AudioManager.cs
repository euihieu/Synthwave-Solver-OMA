using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Sources---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------Audio Clip---------")]
    public AudioClip bgMusic;
    public AudioClip jump;
    public AudioClip dash;
    public AudioClip levelFailed;
    public AudioClip levelCompleted;
    public AudioClip gameCompleted;
    public AudioClip buttonOver;
    public AudioClip buttonPress;

    private void Start()
    {
        musicSource.clip = bgMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

