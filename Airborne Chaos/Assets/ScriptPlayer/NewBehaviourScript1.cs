using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public Transform player;           // El jugador (o el objeto que sigue la c�mara)
    public float minX, maxX;          // L�mites del movimiento en el eje X
    public float minY, maxY;          // L�mites del movimiento en el eje Y

    private Camera cam;                // Referencia a la c�mara

    void Start()
    {
        cam = Camera.main;             // Obtener la c�mara principal
    }

    void Update()
    {
        // Obtener la posici�n de la c�mara
        Vector3 newPosition = transform.position;

        // Limitar el movimiento de la c�mara en el eje X
        newPosition.x = Mathf.Clamp(player.position.x, minX, maxX);

        // Limitar el movimiento de la c�mara en el eje Y
        newPosition.y = Mathf.Clamp(player.position.y, minY, maxY);

        // Mantener la misma posici�n en el eje Z si la c�mara es ortogr�fica
        newPosition.z = transform.position.z;

        // Aplicar la nueva posici�n de la c�mara
        transform.position = newPosition;
    }
}
