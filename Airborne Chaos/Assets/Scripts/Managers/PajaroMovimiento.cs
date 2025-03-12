using UnityEngine;

public class PajaroMovimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad del p�jaro

    void Update()
    {
        // Mueve el p�jaro hacia la izquierda
        transform.position += Vector3.left * velocidad * Time.deltaTime;
    }
}
