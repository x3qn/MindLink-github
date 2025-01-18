using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private void Update()
    {
        // Überprüfen, ob die Escape-Taste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMenu();
        }
    }

    public void Endgame()
    {
        Debug.Log("GameOver");
    }

    private void ReturnToMenu()
    {
        // Wechselt zur Szene "Menu"
        SceneManager.LoadScene("Menu");
        Debug.Log("Returning to Menu...");
    }
}