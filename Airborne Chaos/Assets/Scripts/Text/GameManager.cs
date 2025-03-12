using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text contadorTexto; // UI para los obstáculos
    public Text tiempoTexto; // UI para el cronómetro

    private int contadorObstaculos = 0;
    private float tiempoJugado = 0f; // Variable para almacenar el tiempo jugado
    private bool juegoEnMarcha = true; // Para controlar si el tiempo debe seguir aumentando

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (juegoEnMarcha)
        {
            tiempoJugado += Time.deltaTime; // Sumar el tiempo de cada frame
            ActualizarTiempoUI();
        }
    }

    public void IncrementarContador()
    {
        contadorObstaculos++;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        contadorTexto.text = "Obstáculos: " + contadorObstaculos;
    }

    void ActualizarTiempoUI()
    {
        int minutos = Mathf.FloorToInt(tiempoJugado / 60); // Obtener los minutos
        int segundos = Mathf.FloorToInt(tiempoJugado % 60); // Obtener los segundos
        tiempoTexto.text = string.Format("Tiempo: {0:00}:{1:00}", minutos, segundos);
    }

    public void DetenerTiempo() // Llamar a esto si el jugador pierde
    {
        juegoEnMarcha = false;
    }
}
