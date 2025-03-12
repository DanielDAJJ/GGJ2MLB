using UnityEngine;

public class DetectarPunto : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float posicionXParaPunto = -5f; // Coordenada X donde se considera pasada
    private bool yaSumoPunto = false; // Para evitar sumar varias veces

    void Update()
    {
        // Si la bola pasó la posición X definida y no colisionó con el player
        if (!yaSumoPunto && transform.position.x < posicionXParaPunto)
        {
            GameManager.Instance.SumarPunto(); // Sumar punto en el GameManager
            yaSumoPunto = true; // Evita sumar múltiples veces
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si colisiona con el Player, cancela el punto
        if (other.CompareTag("Player"))
        {
            yaSumoPunto = true; // No se sumará el punto
        }
    }
}
