using UnityEngine;

public class circulo : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad del c�rculo

    void Update()
    {
        // Mueve el c�rculo hacia la izquierda
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}

