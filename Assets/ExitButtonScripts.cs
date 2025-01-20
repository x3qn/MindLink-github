using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonScript : MonoBehaviour
{
    // Diese Methode wird aufgerufen, wenn der Exit-Button geklickt wird
    public void ExitGame()
    {
        // W�hrend des Debuggens in der Editor-Umgebung
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Schlie�t die Anwendung, wenn sie gebaut und ausgef�hrt wird
        Application.Quit();
#endif
        Debug.Log("Spiel beendet."); // Optional: Log f�r Debugging
    }
}
