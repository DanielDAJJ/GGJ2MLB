using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class ActivarUI : MonoBehaviour
{
    public GameObject uiPanel; // Arrastra el Panel de la UI en el Inspector
    public Button closeButton; // Botón para cerrar la UI
    public Button botonPausa; // Botón de pausa que se desactivará
    private bool uiActiva = false; // Para saber si la UI está activa
    private bool yaActivado = false; // Evita que se active más de una vez

    private void Start()
    {
        closeButton.onClick.AddListener(CerrarUI); // Asigna la función al botón
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !uiActiva && !yaActivado) // Solo si no ha sido activado antes
        {
            uiPanel.SetActive(true); // Muestra la UI
            botonPausa.gameObject.SetActive(false); // Desactiva el botón de pausa
            Time.timeScale = 0f; // Pausa el tiempo
            uiActiva = true; // Marca la UI como activa
            yaActivado = true; // Evita que vuelva a activarse
        }
    }

    private void Update()
    {
        if (uiActiva && Input.GetKeyDown(KeyCode.Escape)) // Cerrar con Escape
        {
            CerrarUI(); // Llama a la misma función del botón
        }
    }

    public void CerrarUI()
    {
        uiPanel.SetActive(false); // Oculta la UI
        botonPausa.gameObject.SetActive(true); // Reactiva el botón de pausa
        Time.timeScale = 1f; // Reanuda el tiempo
        uiActiva = false; // Marca la UI como inactiva
    }
}
