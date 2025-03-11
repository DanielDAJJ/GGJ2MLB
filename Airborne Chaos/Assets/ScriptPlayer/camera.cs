using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform personaje; // Referencia al personaje
    public Vector3 offset = new Vector3(0, 2, -10); // Desfase de la cámara
    public float suavidad = 5f; // Velocidad de seguimiento

    void LateUpdate()
    {
        if (personaje != null)
        {
            // Interpola suavemente la posición de la cámara hacia la del personaje
            Vector3 posicionDeseada = personaje.position + offset;
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavidad * Time.deltaTime);
        }
    }
}
    