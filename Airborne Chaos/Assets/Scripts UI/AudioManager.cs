using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Para acceso global
    public AudioMixer audioMixer; // Arrastra el AudioMixer aquí en el Inspector

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetScreamVolume(float volume)
    {
        audioMixer.SetFloat("ScreamVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("ScreamVolume", volume);
        PlayerPrefs.Save();
    }
}
