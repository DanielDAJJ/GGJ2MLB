using UnityEngine;

public class AveAudio : MonoBehaviour
{
    public AudioSource audioAve; // Sonido del ave
    public Transform player; // Referencia al jugador
    public float distanciaMaxima = 10f; // Distancia a la que el sonido es mínimo
    public float distanciaMinima = 2f;  // Distancia a la que el sonido es máximo

    void Start()
    {
        if (audioAve == null)
        {
            audioAve = GetComponent<AudioSource>(); // Obtiene el AudioSource automáticamente
        }

        if (audioAve != null)
        {
            audioAve.Play(); // Asegura que el sonido comience
        }
    }

    void Update()
    {
        if (audioAve == null || player == null) return;

        float distancia = Vector3.Distance(transform.position, player.position); // Calcula la distancia al jugador
        float volumen = Mathf.Clamp01(1 - ((distancia - distanciaMinima) / (distanciaMaxima - distanciaMinima)));

        audioAve.volume = volumen; // Ajusta el volumen según la distancia
    }
}
