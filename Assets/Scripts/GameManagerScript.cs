using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [Header("Pause Men�")]
    [Tooltip("Das UI-Panel, das das Pause-Men� darstellt.")]
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    private void Update()
    {
        //�berpr�fen, ob die Escape-Taste gedr�ckt wurde
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
        pauseMenuUI.SetActive(true); //Pause-Men� anzeigen
        Time.timeScale = 0f;        //Spielzeit pausieren
        isPaused = true;
        Debug.Log("Spiel pausiert.");
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); //Pause-Men� ausblenden
        Time.timeScale = 1f;          // pielzeit fortsetzen
        isPaused = false;
        Debug.Log("Spiel fortgesetzt.");
    }
}