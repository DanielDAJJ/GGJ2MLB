using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void OnEnable()
    {
        UpdateSlider();

        // Update the slider values in real time
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void UpdateSlider()
    {
        // Get the current values from the mixer
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.10f);
        float savedSfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.10f);

        // Put sliders values 
        musicSlider.value = savedMusicVolume;
        sfxSlider.value = savedSfxVolume;

        // Apply in AudioMixer
        SetMusicVolume(savedMusicVolume);
        SetSFXVolume(savedSfxVolume);

    }

    public void SetMusicVolume(float volume)
    {   
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        mainMixer.SetFloat("MusicAudio", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        mainMixer.SetFloat("SfxAudio", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    public void OnUpdateValuesSliders()
    {
        UpdateSlider();
    }
}
