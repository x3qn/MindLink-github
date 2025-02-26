using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [Header("Pause Menü")]
    [Tooltip("Das UI-Panel, das das Pause-Menü darstellt.")]
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    private void Update()
    {
        //Überprüfen, ob die Escape-Taste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Endgame()
    {
        Debug.Log("GameOver");
    }

    private void PauseGame()
    {
        pauseMenuUI.SetActive(true); //Pause-Menü anzeigen
        Time.timeScale = 0f;        //Spielzeit pausieren
        isPaused = true;
        Debug.Log("Spiel pausiert.");
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); //Pause-Menü ausblenden
        Time.timeScale = 1f;          // pielzeit fortsetzen
        isPaused = false;
        Debug.Log("Spiel fortgesetzt.");
    }
}