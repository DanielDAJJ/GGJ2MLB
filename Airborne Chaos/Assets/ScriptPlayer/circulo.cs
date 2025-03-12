using UnityEngine;

public class circulo : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad del círculo

    void Update()
    {
        // Mueve el círculo hacia la izquierda
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}

