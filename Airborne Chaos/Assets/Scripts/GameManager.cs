using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject grupoDeadPanel;
    public bool isGameOver = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            StartCoroutine(WaitBeforePause());
        }
    }
    private IEnumerator WaitBeforePause()
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo antes de pausar
        grupoDeadPanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Juego pausado: Fondo y obstáculos detenidos.");
    }
}
