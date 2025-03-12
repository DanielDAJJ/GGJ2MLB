using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int puntos = 0; // Puntos del jugador
    public float tiempo = 0f; // Tiempo transcurrido
    public Text textoPuntos; // UI para los puntos
    public Text textoTiempo; // UI para el tiempo

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    void Update()
    {
        // Contar el tiempo desde el inicio
        tiempo += Time.deltaTime;
        textoTiempo.text = "Tiempo: " + Mathf.FloorToInt(tiempo) + "s"; // Muestra el tiempo en segundos
    }

    public void SumarPunto()
    {
        puntos++;
        textoPuntos.text = "Puntos: " + puntos;
    }
}