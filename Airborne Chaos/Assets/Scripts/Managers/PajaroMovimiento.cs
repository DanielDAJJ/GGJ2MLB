using UnityEngine;

public class PajaroMovimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad del pájaro

    void Update()
    {
        // Mueve el pájaro hacia la izquierda
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}
