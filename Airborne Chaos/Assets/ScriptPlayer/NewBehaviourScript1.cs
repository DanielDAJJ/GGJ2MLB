using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public Transform player;           // El jugador (o el objeto que sigue la cámara)
    public float minX, maxX;          // Límites del movimiento en el eje X
    public float minY, maxY;          // Límites del movimiento en el eje Y

    private Camera cam;                // Referencia a la cámara

    void Start()
    {
        cam = Camera.main;             // Obtener la cámara principal
    }

    void Update()
    {
        // Obtener la posición de la cámara
        Vector3 newPosition = transform.position;

        // Limitar el movimiento de la cámara en el eje X
        newPosition.x = Mathf.Clamp(player.position.x, minX, maxX);

        // Limitar el movimiento de la cámara en el eje Y
        newPosition.y = Mathf.Clamp(player.position.y, minY, maxY);

        // Mantener la misma posición en el eje Z si la cámara es ortográfica
        newPosition.z = transform.position.z;

        // Aplicar la nueva posición de la cámara
        transform.position = newPosition;
    }
}
