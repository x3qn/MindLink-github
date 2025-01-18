using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Diese Methode wird aufgerufen, um ein bestimmtes Level zu laden
    public void LoadLevel(string levelName)
    {
        if (!string.IsNullOrEmpty(levelName))
        {
            SceneManager.LoadScene(levelName);
            Debug.Log($"Loading level: {levelName}");
        }
        else
        {
            Debug.LogError("Level name is invalid or empty!");
        }
    }

    // Methode, um das Spiel zu beenden
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
//{
//    public void PlayGame()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//    }

//    public void QuitGame()
//    {
//        Debug.Log("Quit");
//        Application.Quit();
//    }
//}
