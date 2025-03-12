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
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe un AudioManager, destruye este para evitar duplicados
        }
    }

    void Start()
    {
        // Cargar el volumen guardado y actualizar el slider
        float volumenGuardado = PlayerPrefs.GetFloat("Volumen", 1f);
        audioSource.volume = volumenGuardado;

        // Si hay un slider asignado, actualízalo
        if (sliderSonido != null)
        {
            sliderSonido.value = volumenGuardado;
            sliderSonido.onValueChanged.AddListener(CambiarVolumen);
        }
    }

    public void CambiarVolumen(float nuevoVolumen)
    {
        audioSource.volume = nuevoVolumen; // Ajusta el volumen del AudioSource
        PlayerPrefs.SetFloat("Volumen", nuevoVolumen); // Guarda el volumen
        PlayerPrefs.Save(); // Asegura que el volumen se guarde
    }
}
