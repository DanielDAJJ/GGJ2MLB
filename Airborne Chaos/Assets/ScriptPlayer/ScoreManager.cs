using UnityEngine;
using UnityEngine.UI; // Para actualizar la UI

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // Para acceso global
    public int score = 0; // Puntaje del jugador
    public Text scoreText; // Texto en la UI para mostrar el puntaje

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int points)
    {
        score += points; // Sumar puntos
        UpdateScoreUI(); // Actualizar la UI
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
