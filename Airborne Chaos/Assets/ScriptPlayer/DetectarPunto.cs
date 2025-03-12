using UnityEngine;
using UnityEngine.UI; // Para manejar la UI

public class DetectarPunto : MonoBehaviour
{
    public float posicionXParaPunto = -5f; // Coordenada X donde se considera que la bola pasó
    private bool yaSumoPunto = false; // Evita sumar varias veces
    public Text textoPuntos; // Referencia al UI Text

    private int puntos = 0; // Contador de puntos
    private bool tocoAlPlayer = false; // Verifica si la bola tocó al jugador

    void Update()
    {
        // Si la bola pasó la posición X y NO ha tocado al Player, suma punto
        if (!yaSumoPunto && transform.position.x < posicionXParaPunto && !tocoAlPlayer)
        {
            SumarPunto();
            yaSumoPunto = true; // Evita sumar varias veces
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si colisiona con el Player, marca que tocó al Player
        if (other.CompareTag("Player"))
        {
            tocoAlPlayer = true; // Se evita sumar el punto
        }
    }

    void SumarPunto()
    {
        puntos++; // Aumenta el contador
        textoPuntos.text = "Puntos: " + puntos; // Actualiza el texto en la UI
    }
}
