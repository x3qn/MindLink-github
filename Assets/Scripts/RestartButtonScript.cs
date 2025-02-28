using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    public void RestartLevel()
    {
        //Laedt die aktuell aktive Szene neu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
