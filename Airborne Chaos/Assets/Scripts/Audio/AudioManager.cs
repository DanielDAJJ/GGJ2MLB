using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
public static AudioManager Instance {get; private set;}

    [Header("Audio Mixer")]
    public AudioMixer mainMixer;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip musicClip;
    public AudioClip sfxClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0.50f));
        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume", 0.50f));

        PlayMusic(musicClip);
    }

    public void PlayMusic(AudioClip clip)
    {

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX()
    {
        if (sfxClip != null)
        {
            sfxSource.PlayOneShot(sfxClip);
        }
    }

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("MusicAudio", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SfxAudio", Mathf.Log10(volume) * 20);
    }

}
