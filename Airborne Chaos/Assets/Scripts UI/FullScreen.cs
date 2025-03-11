using UnityEngine;
using UnityEngine.UI;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;

    void Start()
    {
        // Cargar el estado guardado (por defecto es pantalla completa si no hay datos)
        bool pantallaCompleta = PlayerPrefs.GetInt("PantallaCompleta", 1) == 1;
        Screen.fullScreen = pantallaCompleta;

        if (toggle != null)
        {
            toggle.isOn = pantallaCompleta;
            toggle.onValueChanged.AddListener(ActivarPantallaCompleta);
        }
    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
        PlayerPrefs.SetInt("PantallaCompleta", pantallaCompleta ? 1 : 0);
        PlayerPrefs.Save();
    }

    void OnDestroy()
    {
        if (toggle != null)
        {
            toggle.onValueChanged.RemoveListener(ActivarPantallaCompleta);
        }
    }
}
