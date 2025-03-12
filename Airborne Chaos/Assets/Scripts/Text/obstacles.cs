using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del obstáculo
    private bool contado = false; // Evita contar el mismo obstáculo varias veces
    private Transform jugador; // Referencia al jugador

    void Start()
    {
        // Buscar al jugador en la escena por su tag "Player"
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Mueve el obstáculo hacia la izquierda
        transform.position += Vector3.left * velocidad * Time.deltaTime;

        // Si el obstáculo pasa al jugador y aún no ha sido contado
        if (transform.position.x < jugador.position.x && !contado)
        {
            contado = true; // Se marca como contado para evitar duplicados
            GameManager.Instance.IncrementarContador(); // Llamamos al GameManager para sumar puntos
        }
    }
}
