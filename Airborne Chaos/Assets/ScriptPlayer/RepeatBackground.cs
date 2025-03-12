using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float backgroundWidth;      // Ancho del fondo
    private Vector3 startPosition;     // Posición inicial del fondo
    private Camera mainCamera;         // Referencia a la cámara principal
    private float screenWidthInUnits;  // Ancho de la pantalla en unidades del mundo

    void Start()
    {
        // Guardamos la posición inicial
        startPosition = transform.position;

        // Obtenemos la cámara principal
        mainCamera = Camera.main;

        // Calculamos el ancho del fondo (el sprite del fondo)
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            backgroundWidth = spriteRenderer.bounds.size.x;  // Obtenemos el tamaño del fondo
        }
        else
        {
            Debug.LogError("No se encontró SpriteRenderer en " + gameObject.name);
        }

        // Ajustamos el tamaño del fondo para que cubra la pantalla
        screenWidthInUnits = mainCamera.orthographicSize * 2 * Screen.width / Screen.height;

        // Escalamos el fondo para que cubra toda la pantalla
        float scaleX = screenWidthInUnits / backgroundWidth;
        transform.localScale = new Vector3(scaleX, 1f, 1f);
    }

    void Update()
    {
        // Desplazamos el fondo hacia la izquierda de acuerdo a la posición de la cámara
        transform.position += Vector3.left * 2f * Time.deltaTime;

        // Si el fondo ha salido completamente de la cámara (fuera de la vista)
        if (transform.position.x < mainCamera.transform.position.x - screenWidthInUnits / 2)
        {
            // Reposicionamos el fondo al lado del otro fondo
            transform.position += new Vector3(screenWidthInUnits * 2, 0, 0);
        }
    }
}
