using UnityEngine;

public class PersonaAudio : MonoBehaviour
{
    public AudioSource audioPersona; // Sonido de la persona
    public float alturaMaxima = 20f; // Altura donde el sonido es máximo
    public float alturaMinima = 0f;  // Altura donde el sonido desaparece

    void Start()
    {
        if (audioPersona == null)
        {
            audioPersona = GetComponent<AudioSource>(); // Obtiene el AudioSource automáticamente
        }

        if (audioPersona != null)
        {
            audioPersona.Play(); // Asegura que el sonido comience
        }
    }

    void Update()
    {
        if (audioPersona == null) return;

        float alturaActual = transform.position.y; // Obtiene la altura de la persona
        float volumen = Mathf.Clamp01((alturaActual - alturaMinima) / (alturaMaxima - alturaMinima));

        audioPersona.volume = volumen; // Ajusta el volumen según la altura

        // Opcional: Detener el sonido cuando la persona toca el suelo
        if (alturaActual <= alturaMinima)
        {
            audioPersona.Stop();
        }
    }
}
