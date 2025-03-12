using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // Referencia al Text en la UI
    private float elapsedTime = 0f; // Tiempo transcurrido
    private bool isRunning = true; // Controla si el temporizador está activo

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime; // Sumar tiempo
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Minutos
        int seconds = Mathf.FloorToInt(elapsedTime % 60); // Segundos
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Formato MM:SS
    }

    public void StopTimer()
    {
        isRunning = false; // Detiene el conteo
    }

    public void ResumeTimer()
    {
        isRunning = true; // Reactiva el conteo
    }

    public float GetElapsedTime()
    {
        return elapsedTime; // Devuelve el tiempo transcurrido
    }
}
