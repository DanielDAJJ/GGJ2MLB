using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;  // Contenedor del menú de pausa
    public GameObject PauseButton;      // Botón de pausa
    public GameObject GrupoPausa;       // Panel del menú de pausa
    public GameObject GrupoSettings;    // Panel de configuración
    public GameObject BtnPausa; 
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
        BtnPausa.SetActive(true);
        GrupoSettings.SetActive(false);
        PauseButton.SetActive(false); // Ocultar el botón de pausa

        FindObjectOfType<AudioSettings>().OnUpdateValuesSliders();
    }

    // Método para cerrar todos los menús y reanudar el juego
    public void CloseAllMenus()
    {
        isPaused = false;
        Time.timeScale = 1; // REANUDA EL TIEMPO
        ObjetoMenuPausa.SetActive(false);
        GrupoPausa.SetActive(false);
        BtnPausa.SetActive(false);
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

    // Método para cargar otra escena y reanudar el tiempo si estaba pausado
    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NombreMenu, LoadSceneMode.Single);

        FindObjectOfType<AudioSettings>().OnUpdateValuesSliders();
    }
    public void IrAScenePrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ScenePrincipal", LoadSceneMode.Single);
    }
    public void Reload()
    {
        // Asegurar que todos los menús están cerrados
        CloseAllMenus();

        // Restaurar el tiempo en caso de que esté pausado
        Time.timeScale = 1;

        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
