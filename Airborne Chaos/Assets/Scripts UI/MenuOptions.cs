using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;  // Contenedor del menú de pausa
    public GameObject PauseButton;      // Botón de pausa
    public GameObject GrupoPausa;       // Panel del menú de pausa
    public GameObject GrupoSalir;       // Panel de salida
    public GameObject GrupoSettings;    // Panel de configuración
    private bool isPaused = false;      // Controla si el juego está pausado

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                CloseAllMenus();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }

    // Método para abrir el menú de pausa desde el botón o con Escape
    public void OpenPauseMenu()
    {
        isPaused = true;
        Time.timeScale = 0; // PAUSA EL TIEMPO
        ObjetoMenuPausa.SetActive(true);
        GrupoPausa.SetActive(true);
        GrupoSalir.SetActive(false);
        GrupoSettings.SetActive(false);
        PauseButton.SetActive(false); // Ocultar el botón de pausa
    }

    // Método para cerrar todos los menús y reanudar el juego
    public void CloseAllMenus()
    {
        isPaused = false;
        Time.timeScale = 1; // REANUDA EL TIEMPO
        ObjetoMenuPausa.SetActive(false);
        GrupoPausa.SetActive(false);
        GrupoSalir.SetActive(false);
        GrupoSettings.SetActive(false);
        PauseButton.SetActive(true);
    }

    // Método para abrir el menú de configuración desde el menú de pausa
    public void OpenSettings()
    {
        GrupoPausa.SetActive(false);
        GrupoSettings.SetActive(true);
    }

    // Método para cerrar el menú de configuración y volver al menú de pausa
    public void CloseSettings()
    {
        GrupoSettings.SetActive(false);
        GrupoPausa.SetActive(true);
    }

    // Método para reanudar el juego desde el botón de reanudar
    public void Reanudar()
    {
        CloseAllMenus();
    }

    public void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Método para cargar otra escena y reanudar el tiempo si estaba pausado
    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NombreMenu, LoadSceneMode.Single);
    }
    //Salir del juego
    // Método para cerrar el juego
    public void SalirDelJuego()
    {
        Application.Quit();
    }

}
