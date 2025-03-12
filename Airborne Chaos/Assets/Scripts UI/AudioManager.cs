using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource audioSource; // Fuente de audio principal
    public Slider sliderSonido; // Referencia al Slider de volumen

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        // Cargar el volumen guardado (si hay uno) y actualizar el slider
        float volumenGuardado = PlayerPrefs.GetFloat("Volumen", 1f);
        audioSource.volume = volumenGuardado;
        sliderSonido.value = volumenGuardado;

        // Agregar un listener al slider para cambiar el volumen en tiempo real
        sliderSonido.onValueChanged.AddListener(CambiarVolumen);
    }

    public void CambiarVolumen(float nuevoVolumen)
    {
        audioSource.volume = nuevoVolumen; // Ajusta el volumen del AudioSource
        PlayerPrefs.SetFloat("Volumen", nuevoVolumen); // Guarda el volumen
    }
}
