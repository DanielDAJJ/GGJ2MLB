using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del obst�culo
    private bool contado = false; // Evita contar el mismo obst�culo varias veces
    private Transform jugador; // Referencia al jugador

    void Start()
    {
        // Buscar al jugador en la escena por su tag "Player"
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Mueve el obst�culo hacia la izquierda
        transform.position += Vector3.left * velocidad * Time.deltaTime;

        // Si el obst�culo pasa al jugador y a�n no ha sido contado
        if (transform.position.x < jugador.position.x && !contado)
        {
            contado = true; // Se marca como contado para evitar duplicados
            GameManager.Instance.IncrementarContador(); // Llamamos al GameManager para sumar puntos
        }
    }
}
