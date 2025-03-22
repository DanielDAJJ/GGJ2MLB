using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.50f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.50f);

        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("MusicAudio", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SfxAudio", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
}
